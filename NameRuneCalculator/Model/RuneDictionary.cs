using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace NameRuneCalculator.Model
{
  public class RuneDictionary
  {
    private Dictionary<char, RuneValue> _runeDictionary;

    public RuneDictionary(IEnumerable<RuneValue> values)
    {
      UpdateDictionary(values);
    }


    public void UpdateDictionary(IEnumerable<RuneValue> values)
    {
      _runeDictionary = values.ToDictionary(v => char.ToUpper(v.AlphaChar));
    }

    public RuneValue? GetRuneValue(char c)
    {
      _runeDictionary.TryGetValue(char.ToUpper(c), out var rune);
      return rune;
    }

    public int GetValueOfChar(char c)
    {
      return GetRuneValue(c)?.Value ?? -1;
    }

    public string GetRuneOfChar(char c)
    {
      return GetRuneValue(c)?.RuneName ?? "NOT_FOUND";
    }

    public Color GetColorOfChar(char c)
    {
      return GetRuneValue(c)?.Color ?? Color.Black;
    }

    public int GetValueOfString(string str)
    {
      var noSpaceString = str.Replace(" ", "");
      return noSpaceString.Sum(c => GetValueOfChar(c));
    }
  }
}

