using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NameRuneCalculator.Helpers
{
  public class ColorJsonConverter : JsonConverter<Color>
  {
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      var colorString = reader.GetString();
      return Color.FromName(colorString ?? "White");
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
      writer.WriteStringValue(value.Name);
    }
  }
}
