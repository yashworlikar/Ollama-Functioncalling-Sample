using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace OllamaSample
{
    /// <summary>
    /// Simple plugin that just returns the time.
    /// </summary>
    public class MyTimePlugin
    {
        [KernelFunction, Description("Get the current time")]
        public DateTimeOffset Time() => DateTimeOffset.Now;
    }


    /// <summary>
    /// Class that represents a controllable light bulb.
    /// </summary>
    [Description("Represents a light bulb")]
    public class MyLightPlugin(bool turnedOn = false)
    {
        private bool _turnedOn = turnedOn;

        [KernelFunction, Description("Returns whether this light is on")]
        public bool IsTurnedOn() => _turnedOn;

        [KernelFunction, Description("Turn on this light")]
        public void TurnOn() => _turnedOn = true;

        [KernelFunction, Description("Turn off this light")]
        public void TurnOff() => _turnedOn = false;
    }

    /// <summary>
    /// Class that represents a controllable alarm.
    /// </summary>
    public class MyAlarmPlugin
    {
        private string _hour;

        public MyAlarmPlugin(string providedHour)
        {
            this._hour = providedHour;
        }

        [KernelFunction, Description("Sets an alarm at the provided time")]
        public string SetAlarm(string time)
        {
            this._hour = time;
            return GetCurrentAlarm();
        }

        [KernelFunction, Description("Get current alarm set")]
        public string GetCurrentAlarm()
        {
            return $"Alarm set for {_hour}";
        }
    }
}
