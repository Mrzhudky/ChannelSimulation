using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pcieDriverHelper;
using System.IO;

namespace ChanGenTool
{
    class PcieOperation
    {
        public enum PcieRegAddr
        {
            IsRun = 0x100,       //1启动，0停止
            IsAddNoise = 0x104,  //1加噪，0不加噪
            SNR = 0x108,         //信噪比
            IsAddFad = 0x10c,    //1--加衰落，0--不加衰落
            FadMode = 0x110,     //1为动态，发0为静态
            DDRReset = 0x114,    //发1用于DDR3复位
            FileMode = 0x118,    //0--任意波文件 1--衰落文件
            ArbWaveSize = 0x11c, //发32bit文件大小
            FadingSize = 0x120,  //衰落文件大小
            FirstDelay = 0x124,  //第一条径的时延
            SecondDelay = 0x128, //第二条径的时延
            ThirdDelay = 0x12c,  //第三条径的时延
            FourthDelay = 0x130, //第四条径的时延
            FifthDelay = 0x134,  //第五条径的时延
            SixthDelay = 0x138,  //第六条径的时延
            PathLoss = 0x13c,    //损耗
            ModulateType = 0x224,//调制信号类型
            FilterType = 0x228,  //滤波类型
            FilterTimes = 0x22c, //成型滤波器倍数:3
            SignalType = 0x238,  //信号类型
            SymbolNum = 0x23c,   //码元数量:0--10
            DataSource = 0x240,  //数据源
            DecimalInter = 0x258,//小数内插倍数
            MappingData = 0x1000,//内部码元映射寄存器起始地址
            Frequency = 0x2000,  //单音、双音、脉冲的频率
            DutyCycle = 0x2004   //脉冲的占空比
        }

        public static bool SetPcieReg(PcieRegAddr addr,UInt32 data,out string errorMsg)
        {
            if (addr == PcieRegAddr.FadingSize || addr == PcieRegAddr.ArbWaveSize)
            {
                data = data * 8 / 512 - 1;
            }
            if (!PcieDriver.SetDeviceRegister((UInt32)addr,data))
            {
                errorMsg = PcieDriver.GetLastDeviceError();
                return false;
            }
            errorMsg = "";
            return true;
        }

        public static bool DMATransferFile(string filePath, out string errorMsg)
        {
            try
            {
                FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader bReader = new BinaryReader(fStream);
                long bufSizeMax = PcieDriver.MAX_BUF_SIZE;
                uint bufCount = (uint)(fStream.Length / bufSizeMax);
                uint lenExtra = (uint)(fStream.Length % bufSizeMax);
                uint alignByte = 0x400; 
                if ((lenExtra & (alignByte - 1)) != 0)
                {
                    lenExtra = lenExtra & ~(alignByte - 1) + alignByte;
                }

                byte[] buf; 
                for (int i = 0; i < bufCount; i++)
                {
                    buf = new byte[bufSizeMax];
                    buf = bReader.ReadBytes(buf.Length);
                    if (!PcieDriver.DmaToDevice(buf))
                    {
                        errorMsg = PcieDriver.GetLastDeviceError();
                        return false;
                    }
                }
                if (lenExtra > 0)
                {
                    buf = new byte[lenExtra];
                    bReader.ReadBytes((int)lenExtra).CopyTo(buf, 0);
                    if (!PcieDriver.DmaToDevice(buf))
                    {
                        errorMsg = PcieDriver.GetLastDeviceError();
                        return false;
                    }
                }
                errorMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }

        }

        public bool SendSignalType(uint data,out string errorMsg)
        {
            return SetPcieReg(PcieRegAddr.SignalType,data,out errorMsg);
        }
        /// <summary>
        /// 发送频率控制字
        /// </summary>
        /// <param name="fre">信号频率，单位Hz</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns></returns>
        public bool SendFrequency(double fre, out string errorMsg)
        {
            UInt32 data;
            fre = fre / 250000000 * Math.Pow(2, 32);
            data = (UInt32)Math.Floor(fre);
            return SetPcieReg(PcieRegAddr.Frequency, data, out errorMsg);
        }

        public bool SendDutyCycle(double duty, double fre, out string errorMsg)
        {
            double dutyCycle = 250e6 / fre / 100 * duty;
            uint data = (UInt32)Math.Floor(dutyCycle);
            return SetPcieReg(PcieRegAddr.DutyCycle, data, out errorMsg);
        }

        public bool SendDecimalInter(double rate, out string errorMsg)
        {
            UInt32 data;
            rate = Math.Pow(2, 32) / 250000000 * 4 * rate;
            data = (UInt32)Math.Round(rate);
            return SetPcieReg(PcieRegAddr.DecimalInter, data, out errorMsg);
            
        }

        public bool SendSymbolNum(uint data, out string errorMsg)
        {
            return SetPcieReg(PcieRegAddr.SignalType, data, out errorMsg);
        }

        public bool SendDataSourceIndex(uint data, out string errorMsg)
        {
            return SetPcieReg(PcieRegAddr.DataSource, data, out errorMsg);
        }

        public bool SendFilterType(uint data, out string errorMsg)
        {
            //配置滤波类型
            if (SetPcieReg(PcieRegAddr.FilterType, data, out errorMsg))
            {
                return false;
            }
            //配置滤波器倍数
            if (SetPcieReg(PcieRegAddr.FilterTimes, 3, out errorMsg))
            {
                return false;
            }
            return true;
        }

        public bool BeforeTransferFile(uint fileMode, uint fileLength, out string errorMsg)
        {
            if (!SetPcieReg(PcieRegAddr.DDRReset, 1, out errorMsg))
            {
                return false;
            }
            switch (fileMode)
            {
                case 0: //任意波文件
                    if (!SetPcieReg(PcieRegAddr.ArbWaveSize, fileLength, out errorMsg))
                    {
                        return false;
                    }
                    if (!SetPcieReg(PcieRegAddr.FileMode, 0, out errorMsg))
                    {
                        return false;
                    }
                    break;
                case 1: //衰落文件
                    if (!SetPcieReg(PcieRegAddr.FadingSize, fileLength, out errorMsg))
                    {
                        return false;
                    }
                    if (!SetPcieReg(PcieRegAddr.FileMode, 1, out errorMsg))
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }
            
            if (!SetPcieReg(PcieRegAddr.DDRReset, 0, out errorMsg))
            {
                return false;
            }
            return true;
        }

        public bool IsAddFading(uint isAdd, out string errorMsg)
        {
            return SetPcieReg(PcieRegAddr.IsAddFad, isAdd, out errorMsg);
        }

        public bool IsRun(uint isRun, out string errorMsg)
        {
            return SetPcieReg(PcieRegAddr.IsRun, isRun, out errorMsg);
        }

        public bool IsAddNoise(uint isAdd, out string errorMsg)
        {
            return SetPcieReg(PcieRegAddr.IsAddNoise, isAdd,out errorMsg);
        }

        public bool SendSNR(double dbSnr, out string errorMsg)
        {
            double lineSnr = Math.Pow(10, -1 * dbSnr / 10);
            uint uintSnr = (uint)Math.Floor(Math.Sqrt(lineSnr / 1000) * 16383.0);
            return SetPcieReg(PcieRegAddr.SNR, uintSnr, out errorMsg);
        }

        public bool SendMapData(string fileName, uint dataNum, out string errorMsg)
        {
            errorMsg = "";
            StreamReader sr = new StreamReader(fileName, Encoding.Default);
            String line;
            UInt32 hexData = 0;
            for (int i = 0; i < dataNum; i++)
            {
                line = sr.ReadLine();
                if (line != "")
                {
                    hexData = Convert.ToUInt32(line, 16);
                    if (!SetPcieReg(PcieRegAddr.MappingData + 4 * i, hexData, out errorMsg))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

     
    }
}
