using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyArmClient
{
    public class CalibrationData
    {
        public int Angle;
        public int Pulses;
        public int RawSensor;
    }

    public class AxisCalibration
    {
        public int MinimumPulses;
        public int MaximumPulses;

        public CalibrationData Min = new CalibrationData();
        public CalibrationData Max = new CalibrationData();

        public double GetAngleForSensorReading(Int16 sensorReading)
        {
            //if (sensorReading < Min.RawSensor) sensorReading = (Int16)Min.RawSensor;
            //if (sensorReading > Max.RawSensor) sensorReading = (Int16)Max.RawSensor;

            return Map(sensorReading, Min.RawSensor, Max.RawSensor, Min.Angle, Max.Angle);
        }

        public Int16 GetPulsesForSensorReading(Int16 sensorReading)
        {
            //if (sensorReading < Min.RawSensor) sensorReading = (Int16)Min.RawSensor;
            //if (sensorReading > Max.RawSensor) sensorReading = (Int16)Max.RawSensor;

            return Map(sensorReading, Min.RawSensor, Max.RawSensor, Min.Pulses, Max.Pulses);
        }

        public Int16 GetPulsesForAngle(double angle)
        {
            if (angle < Min.Angle) angle = Min.Angle;
            if (angle > Max.Angle) angle = Max.Angle;

            return Map(angle, Min.Angle, Max.Angle, Min.Pulses, Max.Pulses);
        }

        public static Int16 Map(double val, int fromMin, int fromMax, int toMin, int toMax)
        {
            int fromRange = fromMax - fromMin;
            int toRange = toMax - toMin;

            double startVal = val - fromMin;
            double x = (double)toRange * startVal / (double)fromRange;

            return (Int16)(x + toMin);
        }
    }

    public class AxesCalibration
    {
        public AxisCalibration Left = new AxisCalibration();
        public AxisCalibration Right = new AxisCalibration();
        public AxisCalibration Rotation = new AxisCalibration();
        public AxisCalibration Gripper = new AxisCalibration();

        public void Save(string fileName)
        {
            using (var w = new StreamWriter(fileName))
            {
                var s = new XmlSerializer(typeof(AxesCalibration));
                s.Serialize(w, this);
            }
        }

        public static AxesCalibration Load(string fileName)
        {
            using (var r = new StreamReader(fileName))
            {
                var s = new XmlSerializer(typeof(AxesCalibration));
                return s.Deserialize(r) as AxesCalibration;
            }
        }
    }
}
