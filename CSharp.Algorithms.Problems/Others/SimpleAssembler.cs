namespace CSharp.Algorithms.Problems.Others;

//https://www.codewars.com/kata/58e24788e24ddee28e000053/train/csharp
public static class SimpleAssembler
{
    public static Dictionary<string, int> Interpret(string[] program)
    {
        Dictionary<string, int> registers = new Dictionary<string, int>();
        var splitedText = program.Select(line => line.Split()).ToList();
        int val;

        for (var i = 0; i < splitedText.Count; i++)
        {
            switch (splitedText[i][0])
            {
                case "mov" when registers.ContainsKey(splitedText[i][1]):
                    registers[splitedText[i][1]] = int.TryParse(splitedText[i][2], out val) ? val : registers[splitedText[i][2]];
                    break;
                case "mov":
                    registers.Add(splitedText[i][1], int.TryParse(splitedText[i][2], out val) ? val : registers[splitedText[i][2]]);
                    break;
                case "inc":
                    registers[splitedText[i][1]]++;
                    break;
                case "dec":
                    registers[splitedText[i][1]]--;
                    break;
                case "jnz" when int.TryParse(splitedText[i][1], out val) ? val != 0: registers[splitedText[i][1]] != 0:
                    i += int.Parse(splitedText[i][2]) - 1;
                    break;
                default:
                    break;
            }
        }
            
        return registers;
    }

    public static Dictionary<string, int> InterpretBestCodeWars(string[] program)
    {
        var memory = new Dictionary<string, int>();
        int GetValue(string s) => int.TryParse(s, out var tmp) ? tmp : memory[s];
        for (var pointer = 0; pointer < program.Length; pointer++)
        {
            var values = program[pointer].Split();
            var _ = values[0] switch
            {
                "mov" => memory[values[1]] = GetValue(values[2]),
                "inc" => memory[values[1]]++,
                "dec" => memory[values[1]]--,
                "jnz" => pointer += GetValue(values[1]) != 0 ? GetValue(values[2]) - 1 : 0,
                _ => throw new Exception("Input error")
            };
        }

        return memory;
    }
}