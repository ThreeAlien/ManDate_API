using AutoMapper.Execution;

namespace mandate.Utility.Extension;

public static class StringExtension
{
    /// <summary>
    /// 將數字取至第五位並四捨五入
    /// 例：11538862.986333579 -> 11.54
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static double ToRoundPercentage(double? input)
    {
        if (input == null) return 0;
        // 除以1000000，然後四捨五入到小數點後兩位
        double roundedToDecimal = Math.Round((double)(input / 1000000), 2);
        return roundedToDecimal;
    }
}
