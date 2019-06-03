using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5NumberConverter
{
    static class NumberToString
    {
        public enum TextCase { Nominative/*Кто? Что?*/, Genitive/*Кого? Чего?*/, Dative/*Кому? Чему?*/, Accusative/*Кого? Что?*/, Instrumental/*Кем? Чем?*/, Prepositional/*О ком? О чём?*/ };

        static string zero = "ноль";
        static string firstMale = "один";
        static string firstFemale = "одна";
        static string firstFemaleAccusative = "одну";
        static string firstMaleGenetive = "одно";
        static string secondMale = "два";
        static string secondFemale = "две";
        static string secondMaleGenetive = "двух";
        static string secondFemaleGenetive = "двух";

        static readonly string[] from3till19 =
        {
        "", "три", "четыре", "пять", "шесть",
        "семь", "восемь", "девять", "десять", "одиннадцать",
        "двенадцать", "тринадцать", "четырнадцать", "пятнадцать",
        "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
        };
        static readonly string[] from3till19Genetive =
        {
        "", "трех", "четырех", "пяти", "шести",
        "семи", "восеми", "девяти", "десяти", "одиннадцати",
        "двенадцати", "тринадцати", "четырнадцати", "пятнадцати",
        "шестнадцати", "семнадцати", "восемнадцати", "девятнадцати"
        };
        static readonly string[] tens =
        {
        "", "двадцать", "тридцать", "сорок", "пятьдесят",
        "шестьдесят", "семьдесят", "восемьдесят", "девяносто"
        };
        static readonly string[] tensGenetive =
        {
        "", "двадцати", "тридцати", "сорока", "пятидесяти",
        "шестидесяти", "семидесяти", "восьмидесяти", "девяноста"
        };
        static readonly string[] hundreds =
        {
        "", "сто", "двести", "триста", "четыреста",
        "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
        };
        static readonly string[] hundredsGenetive =
        {
        "", "ста", "двухсот", "трехсот", "четырехсот",
        "пятисот", "шестисот", "семисот", "восемисот", "девятисот"
        };
        static readonly string[] thousands =
        {
        "", "тысяча", "тысячи", "тысяч"
        };
        static readonly string[] thousandsAccusative =
        {
        "", "тысячу", "тысячи", "тысяч"
        };
        static readonly string[] millions =
        {
        "", "миллион", "миллиона", "миллионов"
        };
        static readonly string[] billions =
        {
        "", "миллиард", "миллиарда", "миллиардов"
        };
        static readonly string[] trillions =
        {
        "", "трилион", "трилиона", "триллионов"
        };


        static bool IsPluralGenitive(int _digits)
        {
            if (_digits >= 5 || _digits == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static bool IsSingularGenitive(int _digits)
        {
            if (_digits >= 2 && _digits <= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int LastDigit(long _amount)
        {
            long amount = _amount;

            if (amount >= 100)
            { amount = amount % 100; }

            if (amount >= 20)
            { amount = amount % 10; }

            return (int)amount;
        }



        static string MakeText(int _digits, string[] _hundreds, string[] _tens, string[] _from3till19, string _second, string _first, string[] _power)
        {
            string result = string.Empty;
            int digits = _digits;

            if (digits >= 100)
            {
                result += _hundreds[digits / 100] + " ";
                digits = digits % 100;
            }
            if (digits >= 20)
            {
                result += _tens[digits / 10 - 1] + " ";
                digits = digits % 10;
            }

            if (digits >= 3)
            {
                result += _from3till19[digits - 2] + " ";
            }
            else if (digits == 2)
            {
                result += _second + " ";
            }
            else if (digits == 1)
            {
                result += _first + " ";
            }

            if (_digits != 0 && _power.Length > 0)
            {
                digits = LastDigit(_digits);

                if (IsPluralGenitive(digits))
                {
                    result += _power[3] + " ";
                }
                else if (IsSingularGenitive(digits))
                {
                    result += _power[2] + " ";
                }
                else
                {
                    result += _power[1] + " ";
                }
            }

            return result;
        }

        public static string NumeralsToTxt(long _sourceNumber, TextCase _case, bool _isMale, bool _firstCapital)
        {
            string result = string.Empty;
            long number = _sourceNumber;
            int remainder;
            int power = 0;

            if ((number >= (long)Math.Pow(10, 15)) || number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Слишком большие значение, а также те, которые меньше нуля не обрабатываются");
            }

            while (number > 0)
            {
                remainder = (int)(number % 1000);
                number = number / 1000;

                switch (power)
                {
                    case 12:
                        result = MakeText(remainder, hundreds, tens, from3till19, secondMale, firstMale, trillions) + result;
                        break;
                    case 9:
                        result = MakeText(remainder, hundreds, tens, from3till19, secondMale, firstMale, billions) + result;
                        break;
                    case 6:
                        result = MakeText(remainder, hundreds, tens, from3till19, secondMale, firstMale, millions) + result;
                        break;
                    case 3:
                        switch (_case)
                        {
                            case TextCase.Accusative:
                                result = MakeText(remainder, hundreds, tens, from3till19, secondFemale, firstFemaleAccusative, thousandsAccusative) + result;
                                break;
                            default:
                                result = MakeText(remainder, hundreds, tens, from3till19, secondFemale, firstFemale, thousands) + result;
                                break;
                        }
                        break;
                    default:
                        string[] powerArray = { };
                        switch (_case)
                        {
                            case TextCase.Genitive:
                                result = MakeText(remainder, hundredsGenetive, tensGenetive, from3till19Genetive, _isMale ? secondMaleGenetive : secondFemaleGenetive, _isMale ? firstMaleGenetive : firstFemale, powerArray) + result;
                                break;
                            case TextCase.Accusative:
                                result = MakeText(remainder, hundreds, tens, from3till19, _isMale ? secondMale : secondFemale, _isMale ? firstMale : firstFemaleAccusative, powerArray) + result;
                                break;
                            default:
                                result = MakeText(remainder, hundreds, tens, from3till19, _isMale ? secondMale : secondFemale, _isMale ? firstMale : firstFemale, powerArray) + result;
                                break;
                        }
                        break;
                }

                power += 3;
            }

            if (_sourceNumber == 0)
            {
                result = zero + " ";
            }

            if (result != "" && _firstCapital)
                result = result.Substring(0, 1).ToUpper() + result.Substring(1);

            return result.Trim();
        }

    }
}
