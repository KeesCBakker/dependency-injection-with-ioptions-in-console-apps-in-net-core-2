﻿namespace KeesTalksTech.Utilities.Roman.Numerals.Test;

public class Example
{
    [Fact]
    public void TesT()
    {
        RomanNumeral I = "I"!;
        RomanNumeral IV = "IV"!;

        int a = IV - 1;
        int b = 4 - I;
        int c = IV - "I"!;
        int d = (RomanNumeral) "IV"! - I;
        int e = IV - I;

        Assert.Equivalent(3, a);
        Assert.Equivalent(3, b);
        Assert.Equivalent(3, c);
        Assert.Equivalent(3, d);
        Assert.Equivalent(3, e);

        string f = IV - 1;
        string g = 4 - I;
        string h = IV - "I";
        string i = "IV" - I;
        string j = IV - I;

        Assert.Equivalent("III", f);
        Assert.Equivalent("III", g);
        Assert.Equivalent("III", h);
        Assert.Equivalent("III", i);
        Assert.Equivalent("III", j);

        RomanNumeral k = IV - 1;
        RomanNumeral l = 4 - I;
        RomanNumeral m = IV - "I";
        RomanNumeral n = "IV" - I;
        RomanNumeral o = IV - I;

        Assert.Equivalent("III", k.ToString());
        Assert.Equivalent("III", l.ToString());
        Assert.Equivalent("III", m.ToString());
        Assert.Equivalent("III", n.ToString());
        Assert.Equivalent("III", o.ToString());
    }
}