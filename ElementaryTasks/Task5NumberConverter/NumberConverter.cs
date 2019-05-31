using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5NumberConverter
{
    public static class NumberConverter
    {
        //Получить пропись числа с согласованной единицей измерения.
        public static StringBuilder LowerCase(decimal number, IMeasurementUnits measurentUnit, StringBuilder result)
        {
            string error = CheckNumber(number);
            if (error != null) throw new ArgumentException(error, "число");

            // Целочисленные версии работают в разы быстрее, чем decimal.
            if (number <= uint.MaxValue)
            {
                LowerCase((uint)number, measurentUnit, result);
            }
            else if (number <= ulong.MaxValue)
            {
                LowerCase((ulong)number, measurentUnit, result);
            }
            else
            {
                MyStringBuilder mySb = new MyStringBuilder(result);

                decimal div1000 = Math.Floor(number / 1000);
                LowerCaseHighClasses(div1000, 0, mySb);
                LowerCaseClasses((uint)(number - div1000 * 1000), measurentUnit, mySb);
            }

            return result;
        }

        public static StringBuilder LowerCase(double number, IMeasurementUnits measurentUnit, StringBuilder result)
        {
            string error = CheckNumber(number);
            if (error != null) throw new ArgumentException(error, "число");

            if (number <= uint.MaxValue)
            {
                LowerCase((uint)number, measurentUnit, result);
            }
            else if (number <= ulong.MaxValue)
            {
                // Пропись с ulong выполняется в среднем в 2 раза быстрее.
                LowerCase((ulong)number, measurentUnit, result);
            }
            else
            {
                MyStringBuilder mySb = new MyStringBuilder(result);

                double div1000 = Math.Floor(number / 1000);
                LowerCaseHighClasses(div1000, 0, mySb);
                LowerCaseClasses((uint)(number - div1000 * 1000), measurentUnit, mySb);
            }

            return result;
        }

        public static StringBuilder LowerCase(ulong number, IMeasurementUnits measurentUnit, StringBuilder result)
        {
            if (number <= uint.MaxValue)
            {
                LowerCase((uint)number, measurentUnit, result);
            }
            else
            {
                MyStringBuilder mySb = new MyStringBuilder(result);

                ulong div1000 = number / 1000;
                LowerCaseHighClasses(div1000, 0, mySb);
                LowerCaseClasses((uint)(number - div1000 * 1000), measurentUnit, mySb);
            }

            return result;
        }

        public static StringBuilder LowerCase(uint number, IMeasurementUnits measurentUnit, StringBuilder result)
        {
            MyStringBuilder mySb = new MyStringBuilder(result);

            if (number == 0)
            {
                mySb.Append("ноль");
                mySb.Append(measurentUnit.GenitivePlural);
            }
            else
            {
                uint div1000 = number / 1000;
                LowerCaseHighClasses(div1000, 0, mySb);
                LowerCaseClasses(number - div1000 * 1000, measurentUnit, mySb);
            }

            return result;
        }

        //Записывает  пропись числа, начиная с самого
        // старшего класса до класса с номером <paramref name="номерКласса"/>.
        static void LowerCaseHighClasses(decimal number, int numberOfClass, MyStringBuilder sb)
        {
            if (number == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            decimal div1000 = Math.Floor(number / 1000);
            LowerCaseHighClasses(div1000, numberOfClass + 1, sb);

            uint numberTill999 = (uint)(number - div1000 * 1000);
            if (numberTill999 == 0) return;

            LowerCaseClasses(numberTill999, Классы[numberOfClass], sb);
        }

        static void LowerCaseHighClasses(double number, int numberOfClass, MyStringBuilder sb)
        {
            if (number == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            double div1000 = Math.Floor(number / 1000);
            LowerCaseHighClasses(div1000, numberOfClass + 1, sb);

            uint numberTill999 = (uint)(number - div1000 * 1000);
            if (numberTill999 == 0) return;

            LowerCaseClasses(numberTill999, Классы[numberOfClass], sb);
        }

        static void LowerCaseHighClasses(ulong number, int numberOfClass, MyStringBuilder sb)
        {
            if (number == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            ulong div1000 = number / 1000;
            LowerCaseHighClasses(div1000, numberOfClass + 1, sb);

            uint numberTill999 = (uint)(number - div1000 * 1000);
            if (numberTill999 == 0) return;

            LowerCaseClasses(numberTill999, Классы[numberOfClass], sb);
        }

        static void LowerCaseHighClasses(uint number, int numberOfClass, MyStringBuilder sb)
        {
            if (number == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            uint div1000 = number / 1000;
            LowerCaseHighClasses(div1000, numberOfClass + 1, sb);

            uint numberTill999 = number - div1000 * 1000;
            if (numberTill999 == 0) return;

            LowerCaseClasses(numberTill999, Классы[numberOfClass], sb);
        }

        #region LowerCaseClasses
        /// <summary>
        /// Формирует запись класса с названием, например,
        /// "125 тысяч", "15 рублей".
        /// Для 0 записывает только единицу измерения в род.мн.
        /// </summary>
        private static void LowerCaseClasses(uint числоДо999, IMeasurementUnits класс, MyStringBuilder sb)
        {
            uint числоЕдиниц = числоДо999 % 10;
            uint числоДесятков = (числоДо999 / 10) % 10;
            uint числоСотен = (числоДо999 / 100) % 10;

            sb.Append(Сотни[числоСотен]);

            if ((числоДо999 % 100) != 0)
            {
                Десятки[числоДесятков].Пропись(sb, числоЕдиниц, класс.GenusNumber);
            }

            // Добавить название класса в нужной форме.
            sb.Append(Approve(класс, числоДо999));
        }
        #endregion

        #region CheckNumber


        public static string CheckNumber(decimal число)
        {
            if (число < 0)
                return "Число должно быть больше или равно нулю.";

            if (число != decimal.Floor(число))
                return "Число не должно содержать дробной части.";

            return null;
        }


        public static string CheckNumber(double число)
        {
            if (число < 0)
                return "Число должно быть больше или равно нулю.";

            if (число != Math.Floor(число))
                return "Число не должно содержать дробной части.";

            if (число > MaxDouble)
            {
                return "Число должно быть не больше " + MaxDouble + ".";
            }

            return null;
        }

        #endregion

        #region Approve

        /// <summary>
        /// Согласовать название единицы измерения с числом.
        /// Например, согласование единицы (рубль, рубля, рублей) 
        /// с числом 23 даёт "рубля", а с числом 25 - "рублей".
        /// </summary>
        public static string Approve(IMeasurementUnits единицаИзмерения, uint число)
        {
            uint числоЕдиниц = число % 10;
            uint числоДесятков = (число / 10) % 10;

            if (числоДесятков == 1) return единицаИзмерения.GenitivePlural;
            switch (числоЕдиниц)
            {
                case 1: return единицаИзмерения.NominativeSingular;
                case 2: case 3: case 4: return единицаИзмерения.GenitiveSingular;
                default: return единицаИзмерения.GenitivePlural;
            }
        }

        /// <summary>
        /// Согласовать название единицы измерения с числом.
        /// Например, согласование единицы (рубль, рубля, рублей) 
        /// с числом 23 даёт "рубля", а с числом 25 - "рублей".
        /// </summary>
        public static string Approve(IMeasurementUnits единицаИзмерения, decimal число)
        {
            return Approve(единицаИзмерения, (uint)(число % 100));
        }

        #endregion


        #region Units

        static string ПрописьЦифры(uint цифра, GenusNumber род)
        {
            return Цифры[цифра].Пропись(род);
        }

        abstract class Цифра
        {
            public abstract string Пропись(GenusNumber род);
        }

        class ЦифраИзменяющаясяПоРодам : Цифра, IMeasurementByGenus
        {
            public ЦифраИзменяющаясяПоРодам(
                string мужской,
                string женский,
                string средний,
                string множественное)
            {
                this.мужской = мужской;
                this.женский = женский;
                this.средний = средний;
                this.множественное = множественное;
            }

            public ЦифраИзменяющаясяПоРодам(
                string единственное,
                string множественное)

                : this(единственное, единственное, единственное, множественное)
            {
            }

            private readonly string мужской;
            private readonly string женский;
            private readonly string средний;
            private readonly string множественное;

            #region IИзменяетсяПоРодам Members

            public string Male { get { return this.мужской; } }
            public string Femine { get { return this.женский; } }
            public string Neutral { get { return this.средний; } }
            public string Plural { get { return this.множественное; } }

            #endregion

            public override string Пропись(GenusNumber род)
            {
                return род.GetForm(this);
            }
        }

        class ЦифраНеизменяющаясяПоРодам : Цифра
        {
            public ЦифраНеизменяющаясяПоРодам(string пропись)
            {
                this.пропись = пропись;
            }

            private readonly string пропись;

            public override string Пропись(GenusNumber род)
            {
                return this.пропись;
            }
        }

        private static readonly Цифра[] Цифры = new Цифра[]
        {
            null,
            new ЦифраИзменяющаясяПоРодам ("один", "одна", "одно", "одни"),
            new ЦифраИзменяющаясяПоРодам ("два", "две", "два", "двое"),
            new ЦифраИзменяющаясяПоРодам ("три", "трое"),
            new ЦифраИзменяющаясяПоРодам ("четыре", "четверо"),
            new ЦифраНеизменяющаясяПоРодам ("пять"),
            new ЦифраНеизменяющаясяПоРодам ("шесть"),
            new ЦифраНеизменяющаясяПоРодам ("семь"),
            new ЦифраНеизменяющаясяПоРодам ("восемь"),
            new ЦифраНеизменяющаясяПоРодам ("девять"),
        };

        #endregion
        #region Десятки

        static readonly Десяток[] Десятки = new Десяток[]
        {
            new ПервыйДесяток (),
            new ВторойДесяток (),
            new ОбычныйДесяток ("двадцать"),
            new ОбычныйДесяток ("тридцать"),
            new ОбычныйДесяток ("сорок"),
            new ОбычныйДесяток ("пятьдесят"),
            new ОбычныйДесяток ("шестьдесят"),
            new ОбычныйДесяток ("семьдесят"),
            new ОбычныйДесяток ("восемьдесят"),
            new ОбычныйДесяток ("девяносто")
        };

        abstract class Десяток
        {
            public abstract void Пропись(MyStringBuilder sb, uint числоЕдиниц, GenusNumber род);
        }

        class ПервыйДесяток : Десяток
        {
            public override void Пропись(MyStringBuilder sb, uint числоЕдиниц, GenusNumber род)
            {
                sb.Append(ПрописьЦифры(числоЕдиниц, род));
            }
        }

        class ВторойДесяток : Десяток
        {
            static readonly string[] ПрописьНаДцать = new string[]
            {
                "десять",
                "одиннадцать",
                "двенадцать",
                "тринадцать",
                "четырнадцать",
                "пятнадцать",
                "шестнадцать",
                "семнадцать",
                "восемнадцать",
                "девятнадцать"
            };

            public override void Пропись(MyStringBuilder sb, uint числоЕдиниц, GenusNumber род)
            {
                sb.Append(ПрописьНаДцать[числоЕдиниц]);
            }
        }

        class ОбычныйДесяток : Десяток
        {
            public ОбычныйДесяток(string названиеДесятка)
            {
                this.названиеДесятка = названиеДесятка;
            }

            private readonly string названиеДесятка;

            public override void Пропись(MyStringBuilder sb, uint числоЕдиниц, GenusNumber род)
            {
                sb.Append(this.названиеДесятка);

                if (числоЕдиниц == 0)
                {
                    // После "двадцать", "тридцать" и т.д. не пишут "ноль" (единиц)
                }
                else
                {
                    sb.Append(ПрописьЦифры(числоЕдиниц, род));
                }
            }
        }

        #endregion
        #region Сотни

        static readonly string[] Сотни = new string[]
        {
            null,
            "сто",
            "двести",
            "триста",
            "четыреста",
            "пятьсот",
            "шестьсот",
            "семьсот",
            "восемьсот",
            "девятьсот"
        };

        #endregion
        #region Классы

        #region КлассТысяч

        class КлассТысяч : IMeasurementUnits
        {
            public string NominativeSingular { get { return "тысяча"; } }
            public string GenitiveSingular { get { return "тысячи"; } }
            public string GenitivePlural { get { return "тысяч"; } }
            public GenusNumber GenusNumber { get { return GenusNumber.Femine; } }
        }

        #endregion
        #region Класс

        class Класс : IMeasurementUnits
        {
            readonly string начальнаяФорма;

            public Класс(string начальнаяФорма)
            {
                this.начальнаяФорма = начальнаяФорма;
            }

            public string NominativeSingular { get { return this.начальнаяФорма; } }
            public string GenitiveSingular { get { return this.начальнаяФорма + "а"; } }
            public string GenitivePlural { get { return this.начальнаяФорма + "ов"; } }
            public GenusNumber GenusNumber { get { return GenusNumber.Male; } }
        }

        #endregion

        /// <summary>
        /// Класс - группа из 3 цифр.  Есть классы единиц, тысяч, миллионов и т.д.
        /// </summary>
        static readonly IMeasurementUnits[] Классы = new IMeasurementUnits[]
        {
            new КлассТысяч (),
            new Класс ("миллион"),
            new Класс ("миллиард"),
            new Класс ("триллион"),
            new Класс ("квадриллион"),
            new Класс ("квинтиллион"),
            new Класс ("секстиллион"),
            new Класс ("септиллион"),
            new Класс ("октиллион"),
 
            // Это количество классов покрывает весь диапазон типа decimal.
        };

        #endregion

        #region MaxDouble

        /// <summary>
        /// Максимальное число типа double, представимое в виде прописи.
        /// </summary>
        /// <remarks>
        /// Рассчитывается исходя из количества определённых классов.
        /// Если добавить ещё классы, оно будет автоматически увеличено.
        /// </remarks>
        public static double MaxDouble
        {
            get
            {
                if (maxDouble == 0)
                {
                    maxDouble = CalcMaxDouble();
                }

                return maxDouble;
            }
        }

        private static double maxDouble = 0;

        static double CalcMaxDouble()
        {
            double max = Math.Pow(1000, Классы.Length + 1);

            double d = 1;

            while (max - d == max)
            {
                d *= 2;
            }

            return max - d;
        }

        #endregion

        #region Вспомогательные классы

        #region Форма

        #endregion
        #region MyStringBuilder
        /// <summary>
        /// Вспомогательный класс, аналогичный <see cref="StringBuilder"/>.
        /// Между вызовами <see cref="MyStringBuilder.Append"/> вставляет пробелы.
        /// </summary>
        class MyStringBuilder
        {
            public MyStringBuilder(StringBuilder sb)
            {
                this.sb = sb;
            }

            readonly StringBuilder sb;
            bool insertSpace = false;

            /// <summary>
            /// Добавляет слово <paramref name="s"/>,
            /// вставляя перед ним пробел, если нужно.
            /// </summary>
            public void Append(string s)
            {
                if (string.IsNullOrEmpty(s)) return;

                if (this.insertSpace)
                {
                    this.sb.Append(' ');
                }
                else
                {
                    this.insertSpace = true;
                }

                this.sb.Append(s);
            }

            public override string ToString()
            {
                return sb.ToString();
            }
        }

        #endregion

        #endregion

        #region Перегрузки метода Пропись, возвращающие string

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string Пропись(decimal число, IMeasurementUnits еи)
        {
            return Пропись(число, еи, CapitalLetters.Нет);
        }

        /// <summary>
        /// Возвращает пропись числа.
        /// </summary>
        public static string Пропись(decimal число, IMeasurementUnits еи, CapitalLetters заглавные)
        {
            return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
        }

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string Пропись(double число, IMeasurementUnits еи)
        {
            return Пропись(число, еи, CapitalLetters.Нет);
        }

        /// <summary>
        /// Возвращает пропись числа.
        /// </summary>
        public static string Пропись(double число, IMeasurementUnits еи, CapitalLetters заглавные)
        {
            return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
        }

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string Пропись(ulong число, IMeasurementUnits еи)
        {
            return Пропись(число, еи, CapitalLetters.Нет);
        }

        /// <summary>
        /// Возвращает пропись числа.
        /// </summary>
        public static string Пропись(ulong число, IMeasurementUnits еи, CapitalLetters заглавные)
        {
            return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
        }

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string Пропись(uint число, IMeasurementUnits еи)
        {
            return Пропись(число, еи, CapitalLetters.Нет);
        }

        /// <summary>
        /// Возвращает пропись числа.
        /// </summary>
        public static string Пропись(uint число, IMeasurementUnits еи, CapitalLetters заглавные)
        {
            return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
        }

        internal static string ApplyCaps(StringBuilder sb, CapitalLetters заглавные)
        {
            заглавные.Применить(sb);
            return sb.ToString();
        }

        #endregion
    }

    /// <summary>
    /// Стратегия расстановки заглавных букв.
    /// </summary>
    public abstract class CapitalLetters
    {
        /// <summary>
        /// Применить стратегию к <paramref name="sb"/>.
        /// </summary>
        public abstract void Применить(StringBuilder sb);

        class _ВСЕ : CapitalLetters
        {
            public override void Применить(StringBuilder sb)
            {
                for (int i = 0; i < sb.Length; ++i)
                {
                    sb[i] = char.ToUpperInvariant(sb[i]);
                }
            }
        }

        class _Нет : CapitalLetters
        {
            public override void Применить(StringBuilder sb)
            {
            }
        }

        class _Первая : CapitalLetters
        {
            public override void Применить(StringBuilder sb)
            {
                sb[0] = char.ToUpperInvariant(sb[0]);
            }
        }

        public static readonly CapitalLetters ВСЕ = new _ВСЕ();
        public static readonly CapitalLetters Нет = new _Нет();
        public static readonly CapitalLetters Первая = new _Первая();
    }

    /// <summary>
    /// Описывает тип валюты как совокупность двух единиц измерения - основной и дробной.
    /// Содержит несколько предопределённых валют - рубли, доллары, евро.
    /// </summary>
    /// <remarks>
    /// Предполагается, что основная единица равна 100 дробным. 
    /// </remarks>


    /// <summary>
    /// Класс, хранящий падежные формы единицы измерения в явном виде.
    /// </summary>
    public class MeasurementUnit : IMeasurementUnits
    {
 
        public MeasurementUnit(
            GenusNumber genusNumber,
            string nominativeSingular,
            string genitiveSingular,
            string genitivePlural)
        {
            this.GenusNumber = genusNumber;
            this.nominativeSingular = nominativeSingular;
            this.genitiveSingular = genitiveSingular;
            this.genitivePlural = genitivePlural;
        }

        readonly GenusNumber GenusNumber;
        readonly string nominativeSingular;
        readonly string genitiveSingular;
        readonly string genitivePlural;

        #region IMeasurement Members

        string IMeasurementUnits.NominativeSingular
        {
            get { return this.nominativeSingular; }
        }

        string IMeasurementUnits.GenitiveSingular
        {
            get { return this.genitiveSingular; }
        }

        string IMeasurementUnits.GenitivePlural
        {
            get { return this.genitivePlural; }
        }

        GenusNumber IMeasurementUnits.GenusNumber
        {
            get { return this.GenusNumber; }
        }

        #endregion
    }

    #region GenusNumber


    // Указывает род и число.
    // Может передаваться в качестве параметра "единица измерения" метода 
    // Управляет родом и числом числительных один и два.

    public abstract class GenusNumber : IMeasurementUnits
    {
        internal abstract string GetForm(IMeasurementByGenus word);

        #region Genuses

        class _Male : GenusNumber
        {
            internal override string GetForm(IMeasurementByGenus word)
            {
                return word.Male;
            }
        }

        class _Femine : GenusNumber
        {
            internal override string GetForm(IMeasurementByGenus word)
            {
                return word.Femine;
            }
        }

        class _Neutral : GenusNumber
        {
            internal override string GetForm(IMeasurementByGenus word)
            {
                return word.Neutral;
            }
        }

        class _Plural : GenusNumber
        {
            internal override string GetForm(IMeasurementByGenus word)
            {
                return word.Plural;
            }
        }

        public static readonly GenusNumber Male = new _Male();
        public static readonly GenusNumber Femine = new _Femine();
        public static readonly GenusNumber Neutral = new _Neutral();
        public static readonly GenusNumber Plural = new _Plural();

        #endregion

        #region IMeasurementUnits Members

        GenusNumber IMeasurementUnits.GenusNumber
        {
            get { return this; }
        }

        string IMeasurementUnits.NominativeSingular
        {
            get { return null; }
        }

        string IMeasurementUnits.GenitiveSingular
        {
            get { return null; }
        }

        string IMeasurementUnits.GenitivePlural
        {
            get { return null; }
        }

        #endregion
    }

    #region  IMeasurementByGenus

    internal interface IMeasurementByGenus
    {
        string Male { get; }
        string Femine { get; }
        string Neutral { get; }
        string Plural { get; }
    }

    #endregion

    #endregion

    #region MeasurementUnits

    /// <summary>
    /// Представляет единицу измерения (например, метр, рубль)
    /// и содержит всю необходимую информацию для согласования
    /// этой единицы с числом, а именно - три падежно-числовых формы
    /// и грамматический род / число.
    /// </summary>
    public interface IMeasurementUnits
    {
        /// <summary>
        /// Форма именительного падежа единственного числа.
        /// Согласуется с числительным "один":
        /// одна тысяча, один миллион, один рубль, одни сутки и т.д.
        /// </summary>
        string NominativeSingular { get; }

        /// <summary>
        /// Форма родительного падежа единственного числа.
        /// Согласуется с числительными "один, два, три, четыре":
        /// две тысячи, два миллиона, два рубля, двое суток и т.д.
        /// </summary>
        string GenitiveSingular { get; }

        /// <summary>
        /// Форма родительного падежа множественного числа.
        /// Согласуется с числительным "ноль, пять, шесть, семь" и др:
        /// пять тысяч, пять миллионов, пять рублей, пять суток и т.д.
        /// </summary>
        string GenitivePlural { get; }

        /// <summary>
        /// Род и число единицы измерения.
        /// </summary>
        GenusNumber GenusNumber { get; }
    }

    #endregion





















}
