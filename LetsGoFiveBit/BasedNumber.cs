using System;
using System.Linq;

namespace LetsGoFiveBit
{
    public struct BasedNumber
    {
        public BasedNumber(int numberBase) : this(numberBase, "") { }

        public BasedNumber(int numberBase, string value)
        {
            NumberBase = numberBase;
            Value = value;
        }

        public int NumberBase { get; set; }
        public string Value { get; set; }

        public BasedNumber ConvertToBase(int targetBase)
        {
            if (targetBase == NumberBase)
            {
                return new BasedNumber(this.NumberBase) { Value = this.Value };
            }
            else
            {
                if (targetBase == 10)
                {
                    // multiply positions by powers
                    const char c_DecimalPoint = '.';

                    double _baseTenTotal = 0;
                    char[] _digits = Value.ToCharArray();

                    int _integerPartLength = Value.IndexOf(c_DecimalPoint, 0);
                    int _toPower = _integerPartLength > 0 ? _integerPartLength - 1 : _digits.Length - 1;

                    for (int _index = 0; _index <= _digits.Length - 1; _index++)
                    {
                        if (_digits[_index] != c_DecimalPoint)
                        {
                            _baseTenTotal += ConvertBasedDigitToBaseTenNumber(_digits[_index]) * Math.Pow(NumberBase, _toPower);
                            _toPower -= 1;
                        }
                    }
                    return new BasedNumber(10, Convert.ToString(_baseTenTotal));
                }
                else
                {
                    // convert to a base ten, then from there to target base
                    BasedNumber _baseTen = ConvertToBase(10);

                    double _x = Convert.ToDouble(_baseTen.Value);
                    Int64 _q = 0;
                    double _r = 0;
                    string _digits = "";
                    do
                    {
                        _q = (Int64)_x / targetBase;
                        _r = _x - (_q * targetBase);
                        _digits = $"{ConvertBaseTenNumberToBasedDigit((Int16)_r)}{_digits}";
                        _x = _q;
                    } while (_q != 0);
                    
                    return new BasedNumber(targetBase, _digits);
                }
            }
        }

        /// <summary>
        /// Converts a based digit to the equivalent base ten number - note that this is base independant
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private static Int16 ConvertBasedDigitToBaseTenNumber(char digit)
        {
            char[] _digits = CharConversionArray();
            for (Int16 _index = 0; _index <= _digits.Length - 1; _index++)
            {
                if (_digits[_index] == Char.ToLower(digit))
                {
                    return _index;
                }
            }
            return 0;
        }

        /// <summary>
        /// Performs basic conversion from a decimal number to the equivalent based digit - note that this is base independant
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static char ConvertBaseTenNumberToBasedDigit(Int16 number)
        {
            char[] _digits = CharConversionArray();
            if (number < _digits.Length)
            {
                return Char.ToUpper(_digits[number]);
            }
            return '0';
        }

        private static char[] m_CharConversionArray = null;
        private static char[] CharConversionArray()
        {
            // basic conversion array where index position = decimal number and array entry = based digit (good for up to 36)
            if (m_CharConversionArray == null)
            {
                m_CharConversionArray = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 'v', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            }
            return m_CharConversionArray;
        }

        public static char[] GetValidDigitsForBase(int numberBase)
        {
            return (char[])CharConversionArray().Take(numberBase).ToArray();

        }

        public override bool Equals(object obj)
        {
            if (obj is BasedNumber)
            {
                return base.Equals((BasedNumber)obj);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(BasedNumber obj)
        {
            if (obj.Equals(BasedNumber.Empty())) return false;

            if (obj.NumberBase == this.NumberBase)
            {
                return (this.Value == obj.Value);
            }
            else
            {
                return this.Equals(obj.ConvertToBase(this.NumberBase));
            }
        }

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => $"{this.Value} ^{this.NumberBase}";

        public static BasedNumber Empty() => default(BasedNumber);


        public static BasedNumber operator +(BasedNumber n1, BasedNumber n2)
        {
            var _n1 = Convert.ToDouble(n1.ConvertToBase(10).Value);
            var _n2 = Convert.ToDouble(n2.ConvertToBase(10).Value);
            var _result = new BasedNumber(10, Convert.ToString(_n1 + _n2));
            return _result.ConvertToBase(n1.NumberBase);
        }

        public static BasedNumber operator -(BasedNumber n1, BasedNumber n2)
        {
            var _n1 = Convert.ToDouble(n1.ConvertToBase(10).Value);
            var _n2 = Convert.ToDouble(n2.ConvertToBase(10).Value);
            var _result = new BasedNumber(10, Convert.ToString(_n1 - _n2));
            return _result.ConvertToBase(n1.NumberBase);
        }

        public static BasedNumber operator /(BasedNumber n1, BasedNumber n2)
        {
            var _n1 = Convert.ToDouble(n1.ConvertToBase(10).Value);
            var _n2 = Convert.ToDouble(n2.ConvertToBase(10).Value);
            var _result = new BasedNumber(10, Convert.ToString(_n1 / _n2));
            return _result.ConvertToBase(n1.NumberBase);
        }

        public static BasedNumber operator *(BasedNumber n1, BasedNumber n2)
        {
            var _n1 = Convert.ToDouble(n1.ConvertToBase(10).Value);
            var _n2 = Convert.ToDouble(n2.ConvertToBase(10).Value);
            var _result = new BasedNumber(10, Convert.ToString(_n1 * _n2));
            return _result.ConvertToBase(n1.NumberBase);
        }

    }

}
