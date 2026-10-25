namespace RAW_TO_ENG
{
    enum ArincRowHeaders { SlNo = 0, Packet_Count, Timestamp, Channel, Label, SSM, Parity, Data, Raw_Data, TimestampHi, TimeStampLo }
    public static class Global
    {
        public static int GPS_KAM500_POWERON_TIME_hr = 12;
        public static int GPS_KAM500_POWERON_TIME_mn = 18;
        public static double GPS_KAM500_POWERON_TIME_sec = 8.86;//44288.86
        public static double TimeToDouble(string Timestamp)
        {
            double timeInDouble = 0;
            if (Timestamp.Length > 0)
            {
                var temp_str = Timestamp.Split(':');
                var hrs_str = temp_str[0];
                var min_str = temp_str[1];
                var sec_str = temp_str[2];
                timeInDouble = (Convert.ToDouble(hrs_str) * 3600) + (Convert.ToDouble(min_str) * 60) + (Convert.ToDouble(sec_str) * 1);
                var tempp = GetFormatTime(timeInDouble);
            }
            return timeInDouble;
        }
        public static string GetFormatTime(double time)
        {
            string T2;
            if (time >= 3600)
            {
                T2 = (int)(time / 3600) + ":";
            }
            else
            {
                T2 = "00:";
            }
            if ((time % 3600) >= 60)
            {
                T2 = T2 + (int)((time % 3600) / 60) + ":";
            }
            else
            {
                T2 = T2 + "00:";
            }
            if ((time % 60) > 0)
            {
                T2 = T2 + (int)((time % 60) / 1) + ".";
            }
            else
            {
                T2 = T2 + "00.";
            }
            if ((time % 1) > 0)
            {
                T2 = T2 + ((int)((time % 1) / 0.001)).ToString().PadLeft(3, '0') + ".";
            }
            else
            {
                T2 = T2 + "000.";
            }
            if ((time % 0.001) > 0)
            {
                T2 = T2 + ((time % 1) / 0.001).ToString().Split('.')[1];
            }
            else
            {
                T2 = T2 + "00";
            }
            return T2;

        }
    }
    public class DiscreteRecord
    {
        public string Sl_No { get; set; }
        public string Timestamp { get; set; }
        public double TimestampDouble { get; set; }
        public string Channel { get; set; }
        public string Raw_Data { get; set; }
        public string TimestampHi { get; set; }
        public string TimeStampLo { get; set; }
        public string ParamName { get; set; }

        public DiscreteRecord(string Sl_No, string Timestamp, string Channel, string Raw_Data)
        {
            this.Sl_No = Sl_No;
            this.Timestamp = Timestamp;
            this.Channel = Channel;
            this.Raw_Data = Raw_Data;
            this.TimestampHi = "0";
            this.TimeStampLo = "0";
        }
        public DiscreteRecord()
        {
            this.TimestampHi = "0";
            this.TimeStampLo = "0";
        }
        public DiscreteRecord(DiscreteRecord obj)
        {
            this.Sl_No = obj.Sl_No;
            this.Timestamp = obj.Timestamp;
            this.TimestampDouble = obj.TimestampDouble;
            this.Channel = obj.Channel;
            this.Raw_Data = obj.Raw_Data;
            this.TimestampHi = obj.TimestampHi;
            this.TimeStampLo = obj.TimeStampLo;
            this.ParamName = obj.ParamName;
        }
        public void TimeToDouble()
        {
            this.TimestampDouble = Global.TimeToDouble(this.Timestamp);
            this.TimestampDouble += ((Global.GPS_KAM500_POWERON_TIME_hr * 3600) + (Global.GPS_KAM500_POWERON_TIME_mn * 60) + Global.GPS_KAM500_POWERON_TIME_sec);
            this.Timestamp = Global.GetFormatTime(this.TimestampDouble);
        }
        public string ToString()
        {
            return this.Sl_No + "," + this.Timestamp + "," + this.Channel + "," + this.Raw_Data + "," + this.TimestampHi + "," + this.TimeStampLo + "," + this.ParamName;
        }
    }
    public class AnalogRecord
    {
        public string Sl_No { get; set; }
        public string Timestamp { get; set; }
        public double TimestampDouble { get; set; }
        public string Channel { get; set; }
        public string Raw_Data { get; set; }
        public string TimestampHi { get; set; }
        public string TimeStampLo { get; set; }
        public string ParamName { get; set; }

        public AnalogRecord(string Sl_No, string Timestamp, string Channel, string Raw_Data)
        {
            this.Sl_No = Sl_No;
            this.Timestamp = Timestamp;
            this.Channel = Channel;
            this.Raw_Data = Raw_Data;
            this.TimestampHi = "0";
            this.TimeStampLo = "0";
        }
        public AnalogRecord()
        {
            this.TimestampHi = "0";
            this.TimeStampLo = "0";
        }
        public AnalogRecord(AnalogRecord obj)
        {
            this.Sl_No = obj.Sl_No;
            this.Timestamp = obj.Timestamp;
            this.TimestampDouble = obj.TimestampDouble;
            this.Channel = obj.Channel;
            this.Raw_Data = obj.Raw_Data;
            this.TimestampHi = obj.TimestampHi;
            this.TimeStampLo = obj.TimeStampLo;
            this.ParamName = obj.ParamName;
        }
        public void TimeToDouble()
        {
            this.TimestampDouble = Global.TimeToDouble(this.Timestamp);
            this.TimestampDouble += ((Global.GPS_KAM500_POWERON_TIME_hr * 3600) + (Global.GPS_KAM500_POWERON_TIME_mn * 60) + Global.GPS_KAM500_POWERON_TIME_sec);
            this.Timestamp = Global.GetFormatTime(this.TimestampDouble);
        }
        public string ToString()
        {
            return this.Sl_No + "," + this.Timestamp + "," + this.Channel + "," + this.Raw_Data + "," + this.TimestampHi + "," + this.TimeStampLo + "," + this.ParamName;
        }
    }
    public class ArincRecord
    {
        public string Sl_No { get; set; }
        public string Packet_Count { get; set; }
        public string Timestamp { get; set; }
        public double TimestampDouble { get; set; }
        public string Channel { get; set; }
        public string Label { get; set; }
        public string SSM { get; set; }
        public string Parity { get; set; }
        public string Data { get; set; }
        public string Raw_Data { get; set; }
        public string TimestampHi { get; set; }
        public string TimeStampLo { get; set; }
        public string ParamName { get; set; }

        public ArincRecord(string Sl_No, string Timestamp, string Channel, string Label, string SSM, string Parity, string Data, string Raw_Data)
        {
            this.Sl_No = Sl_No;
            this.Timestamp = Timestamp;
            this.Channel = Channel;
            this.Label = Label;
            this.SSM = SSM;
            this.Parity = Parity;
            this.Data = Data;
            this.Raw_Data = Raw_Data;
            this.TimestampHi = "0";
            this.TimeStampLo = "0";
        }
        public ArincRecord()
        {
            this.TimestampHi = "0";
            this.TimeStampLo = "0";
        }
        public ArincRecord(ArincRecord obj)
        {
            this.Sl_No = obj.Sl_No;
            this.Timestamp = obj.Timestamp;
            this.TimestampDouble = obj.TimestampDouble;
            this.Channel = obj.Channel;
            this.Label = obj.Label;
            this.SSM = obj.SSM;
            this.Parity = obj.Parity;
            this.Data = obj.Data;
            this.Raw_Data = obj.Raw_Data;
            this.TimestampHi = obj.TimestampHi;
            this.TimeStampLo = obj.TimeStampLo;
            this.ParamName = obj.ParamName;
        }
        public void TimeToDouble()
        {
            this.TimestampDouble = Global.TimeToDouble(this.Timestamp);
            this.TimestampDouble += ((Global.GPS_KAM500_POWERON_TIME_hr * 3600) + (Global.GPS_KAM500_POWERON_TIME_mn * 60) + Global.GPS_KAM500_POWERON_TIME_sec);
            this.Timestamp = Global.GetFormatTime(this.TimestampDouble);
        }
        public string ToString()
        {
            this.Packet_Count = this.Sl_No;
            return this.Sl_No + "," + this.Packet_Count + "," + this.Timestamp + "," + this.Channel + "," + this.Label + "," + this.SSM + "," + this.Parity + "," + this.Data + "," + this.Raw_Data + "," + this.TimestampHi + "," + this.TimeStampLo + "," + this.ParamName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            String[] csvfiles = Directory.GetFiles("..\\..\\..\\..\\Data\\01_FTI_RawData", "*.csv");
            List<ArincRecord> ArincData = new List<ArincRecord>();
            List<AnalogRecord> AnalogData = new List<AnalogRecord>();
            List<DiscreteRecord> DiscreteData = new List<DiscreteRecord>();
            Dictionary<string, string> PrevData = new Dictionary<string, string>();
            string currDate = "";
            string currTime = "";
            int tempCount = 0;
            if (csvfiles.Length > 0)
            {
                foreach (string file in csvfiles)
                {
                    string filename = Path.GetFileName(file);
                    string[] ICDINFO = filename.Split('-');
                    if (ICDINFO[0] == "LSS")
                    {
                        Console.WriteLine(filename);
                        int skipLines = 7;
                        var allLines = File.ReadAllLines(file);
                        int lineCount = 0;
                        foreach (string line in File.ReadLines(file))
                        {
                            string[] Data = line.Split(",");
                            if (skipLines-- > 0)
                            {
                                if (tempCount++ < 2)
                                {
                                    string[] TempData = Data[0].Split(":");
                                    if (TempData[0].Trim() == "Current Date")
                                    {
                                        currDate = TempData[1].Trim();
                                    }
                                    else if (TempData[0].Trim() == "Current Time")
                                    {
                                        currTime = TempData[1].Trim() + "-" + TempData[2].Trim() + "-" + TempData[3].Trim();
                                    }
                                    else
                                    {
                                        tempCount--;
                                    }
                                }
                                continue;
                            }
                            if (ICDINFO.Length == 5)
                            {
                                ArincRecord Temp = new ArincRecord();
                                Temp.Channel = ICDINFO[2];
                                Temp.Label = ICDINFO[3];
                                Temp.ParamName = ICDINFO[4].Substring(0, ICDINFO[4].Length - 4);
                                Temp.Timestamp = Data[0].Substring(2, Data[0].Length - 2);
                                Temp.Raw_Data = Data[1];
                                UInt32 RawData = Convert.ToUInt32(Temp.Raw_Data);
                                uint empty = ((RawData >> 8) & 0x1);
                                uint stale = ((RawData >> 7) & 0x1);
                                if ((empty == 0) && (stale == 0))
                                {
                                    RawData = RawData >> 9;
                                    RawData = RawData << 8;
                                    RawData = RawData | Convert.ToUInt32(Temp.Label, 8);
                                    RawData = RawData | ((Convert.ToUInt32(Temp.Raw_Data) & 0x01) << 31);
                                    Temp.Raw_Data = RawData.ToString("X").PadLeft(8, '0');
                                    string key = "Arinc-" + Temp.Channel + "|" + Temp.Label;
                                    string value = Temp.Raw_Data;
                                    bool dataChanged = false;
                                    if (PrevData.ContainsKey(key))
                                    {
                                        if (PrevData[key] != value)
                                        {
                                            dataChanged = true;
                                            PrevData[key] = value;
                                        }
                                        else
                                        {
                                            dataChanged = false;
                                        }
                                    }
                                    else
                                    {
                                        dataChanged = true;
                                        PrevData[key] = value;
                                    }
                                    if (lineCount >= (allLines.Count() - 7 - 1))
                                    {
                                        dataChanged = true;
                                    }
                                    if (dataChanged)
                                    {
                                        Temp.Data = ((RawData >> 8) & 0x1fffff).ToString("X").PadLeft(6, '0');
                                        Temp.SSM = ((RawData >> 29) & 0x03).ToString("X");
                                        Temp.Parity = ((RawData >> 31) & 0x01).ToString("X");
                                        Temp.TimeToDouble();
                                        if (ArincData.Count > 0 && ArincData[ArincData.Count - 1].ParamName == Temp.ParamName && ArincData[ArincData.Count - 1].TimestampDouble > Temp.TimestampDouble)
                                        {
                                            Console.WriteLine(ArincData[ArincData.Count - 1].Timestamp + "|" + Temp.Timestamp);
                                        }
                                        ArincData.Add(new ArincRecord(Temp));
                                    }
                                }
                            }
                            else if (ICDINFO.Length == 4)
                            {
                                if (ICDINFO[1] == "DISCRETE")
                                {
                                    DiscreteRecord Temp = new DiscreteRecord();
                                    Temp.Channel = ICDINFO[2];
                                    Temp.ParamName = ICDINFO[3].Substring(0, ICDINFO[3].Length - 4);
                                    Temp.Timestamp = Data[0].Substring(2, Data[0].Length - 2);
                                    Temp.Raw_Data = (Convert.ToUInt32(Data[1])).ToString("X");
                                    string key = "Discrete-" + Temp.Channel;
                                    string value = Temp.Raw_Data;
                                    bool dataChanged = false;
                                    if (PrevData.ContainsKey(key))
                                    {
                                        if (PrevData[key] != value)
                                        {
                                            dataChanged = true;
                                            PrevData[key] = value;
                                        }
                                        else
                                        {
                                            dataChanged = false;
                                        }
                                    }
                                    else
                                    {
                                        dataChanged = true;
                                        PrevData[key] = value;
                                    }
                                    if (lineCount >= (allLines.Count() - 7 - 1))
                                    {
                                        dataChanged = true;
                                    }
                                    if (dataChanged)
                                    {
                                        Temp.TimeToDouble();
                                        if (DiscreteData.Count > 0 && DiscreteData[DiscreteData.Count - 1].ParamName == Temp.ParamName && DiscreteData[DiscreteData.Count - 1].TimestampDouble > Temp.TimestampDouble)
                                        {
                                            Console.WriteLine(DiscreteData[DiscreteData.Count - 1].Timestamp + "|" + Temp.Timestamp);
                                        }
                                        DiscreteData.Add(new DiscreteRecord(Temp));
                                    }
                                }
                                else
                                {
                                    AnalogRecord Temp = new AnalogRecord();
                                    Temp.Channel = ICDINFO[2];
                                    Temp.ParamName = ICDINFO[3].Substring(0, ICDINFO[3].Length - 4);
                                    Temp.Timestamp = Data[0].Substring(2, Data[0].Length - 2);
                                    Temp.Raw_Data = (Convert.ToUInt32(Data[1])).ToString("X");
                                    Temp.TimeToDouble();
                                    string key = "Analog-" + Temp.Channel;
                                    string value = Temp.Raw_Data;
                                    bool dataChanged = false;
                                    if (PrevData.ContainsKey(key))
                                    {
                                        if (PrevData[key] != value)
                                        {
                                            dataChanged = true;
                                            PrevData[key] = value;
                                        }
                                        else
                                        {
                                            dataChanged = false;
                                        }
                                    }
                                    else
                                    {
                                        dataChanged = true;
                                        PrevData[key] = value;
                                    }
                                    if (lineCount >= (allLines.Count() - 7 - 1))
                                    {
                                        dataChanged = true;
                                    }
                                    if (dataChanged)
                                    {
                                        if (AnalogData.Count > 0 && AnalogData[AnalogData.Count - 1].ParamName == Temp.ParamName && AnalogData[AnalogData.Count - 1].TimestampDouble > Temp.TimestampDouble)
                                        {
                                            Console.WriteLine(AnalogData[AnalogData.Count - 1].Timestamp + "|" + Temp.Timestamp);
                                        }
                                        AnalogData.Add(new AnalogRecord(Temp));
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                            lineCount++;
                        }
                    }
                }
            }
            ArincData = ArincData.OrderBy(x => x.TimestampDouble).ToList();
            using (StreamWriter ArincOutFile = new StreamWriter("..\\..\\..\\..\\Data\\02_PatsFormatData\\" + "Arinc_Log_LSS-" + currDate + "-" + currTime + ".csv"))
            {
                ArincOutFile.WriteLine("SlNo, Packet_Count, Timestamp,Channel,Label,SSM,Parity,Data, Raw_Data, TimestampHi, TimeStampLo, LabelName(for debug)");
                int SlNoArinc = 0;
                foreach (ArincRecord row in ArincData)
                {
                    row.Sl_No = (++SlNoArinc).ToString();
                    ArincOutFile.WriteLine(row.ToString());
                }
            }
            AnalogData = AnalogData.OrderBy(x => x.TimestampDouble).ToList();
            using (StreamWriter AnalogOutFile = new StreamWriter("..\\..\\..\\..\\Data\\02_PatsFormatData\\" + "Analog_Log_LSS-" + currDate + "-" + currTime + ".csv"))
            {
                AnalogOutFile.WriteLine("SlNo, Timestamp,Channel,Raw_Data, TimestampHi, TimeStampLo, LabelName(for debug)");
                int SlNoArinc = 0;
                foreach (AnalogRecord row in AnalogData)
                {
                    row.Sl_No = (++SlNoArinc).ToString();
                    AnalogOutFile.WriteLine(row.ToString());
                }
            }
            DiscreteData = DiscreteData.OrderBy(x => x.TimestampDouble).ToList();
            using (StreamWriter DiscreteOutFile = new StreamWriter("..\\..\\..\\..\\Data\\02_PatsFormatData\\" + "Discrete_Log_LSS-" + currDate + "-" + currTime + ".csv"))
            {
                DiscreteOutFile.WriteLine("SlNo, Timestamp,Channel,Raw_Data, TimestampHi, TimeStampLo, LabelName(for debug)");
                int SlNoArinc = 0;
                foreach (DiscreteRecord row in DiscreteData)
                {
                    row.Sl_No = (++SlNoArinc).ToString();
                    DiscreteOutFile.WriteLine(row.ToString());
                }
            }
        }
    }
}
