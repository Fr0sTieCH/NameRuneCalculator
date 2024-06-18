using NameRuneCalculator.Model;
using System;

namespace NameRuneCalculator.Configuration
{
  public class NameRuneCalculatorConfig
  {
    public string Language { get; set; } = string.Empty;
    public bool NormalizeCharacters { get; set; } = true;
    public RuneValue[] DefaultRunes { get; set; } = Array.Empty<RuneValue>();
    public RuneValue[] UserDefinedRunes { get; set; } = Array.Empty<RuneValue>();
  }
}
