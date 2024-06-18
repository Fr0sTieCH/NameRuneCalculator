using NameRuneCalculator.Helpers;
using System;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace NameRuneCalculator.Model
{
  [Serializable]
  public class RuneValue
  {

    public static RuneValue DeepCopy(RuneValue value)
    {
      return new RuneValue()
      {
        RuneName = value.RuneName,
        AlphaChar = value.AlphaChar,
        Value = value.Value,
        Color = value.Color
      };
    }
    [XmlIgnore]
    public char AlphaCharLower => char.ToLower(AlphaChar);
    public string RuneName { get; set; } = "----";
    public char AlphaChar { get; set; } = '-';
    public int Value { get; set; } = 0;
    [JsonConverter(typeof(ColorJsonConverter))]
    public Color Color { get; set; } = Color.White;
  }
}
