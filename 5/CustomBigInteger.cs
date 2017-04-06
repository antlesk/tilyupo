using System;
using System.Text;

namespace _5_1_2
{
    class CustomBigUInt
    {
        private readonly int _baseNumber = 10;

        public CustomList<int> Digits { get; private set; } = new CustomList<int>();

        public CustomBigUInt(string number)
        {
            if (number[0] == '-')
            {
                throw new ArgumentException("Число не может быть отрицательным!");
            }

            for (int i = number.Length - 1; i >= 0; i--)
            {
                Digits.Add(Convert.ToInt32(number[i].ToString()));
            }

            Trim();
        }

        public CustomBigUInt()
            : this("0")
        {
        }

        public CustomBigUInt(long number)
            :this(number.ToString())
        {
        }

        public CustomBigUInt(CustomBigUInt number)
        {
            foreach (var digit in number.Digits)
            {
                this.Digits.Add(digit);
            }

            this.Trim();
        }

        private void Trim()
        {
            while (Digits[Digits.Length - 1] == 0 && Digits.Length > 1) Digits.Remove(Digits.Length - 1);
        }

        public override bool Equals(object obj)
        {
            CustomBigUInt number = obj as CustomBigUInt;

            if (number == null)
            {
                return false;
            }

            if (number.Digits.Length != Digits.Length)
            {
                return false;
            }

            for (int i = 0; i < Digits.Length; i++)
            {
                if (Digits[i] != number.Digits[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            long hashCode = 0;
            int baseNumber = 41;
            int modulo = (int)1e9 + 7;
            
            foreach (var digit in Digits)
            {
                hashCode = (hashCode * baseNumber + digit) % modulo;
            }

            return (int)hashCode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = Digits.Length - 1; i >= 0; i--)
            {
                result.Append(Convert.ToString(Digits[i]));
            }

            return result.ToString();
        }

        public CustomBigUInt Add(CustomBigUInt number)
        {
            var result = new CustomBigUInt(this);

            int carry = 0;
            for (int i = 0; i < number.Digits.Length || carry != 0; i++)
            {
                if (result.Digits.Length <= i)
                {
                    result.Digits.Add(0);
                }

                if (i < number.Digits.Length)
                {
                    result.Digits[i] += number.Digits[i];
                }

                result.Digits[i] += carry;
                carry = result.Digits[i] / _baseNumber;
                result.Digits[i] %= _baseNumber;
            }

            result.Trim();

            return result;
        }

        public CustomBigUInt Multiply(CustomBigUInt number)
        {
            var result = new CustomBigUInt(0);

            int carry = 0;
            for (int i = 0; i < this.Digits.Length; i++)
            {
                for (int j = 0; j < number.Digits.Length || carry > 0; j++)
                {
                    if (result.Digits.Length <= i + j)
                    {
                        result.Digits.Add(0);
                    }
                    
                    if (j < number.Digits.Length && i < this.Digits.Length)
                    {
                        result.Digits[i + j] += this.Digits[i] * number.Digits[j];
                    }

                    result.Digits[i + j] += carry;
                    carry = result.Digits[i + j] / _baseNumber;
                    result.Digits[i + j] %= _baseNumber;
                }
            }

            result.Trim();

            return result;
        }

        public CustomBigUInt Minus(CustomBigUInt number)
        {
            if (this < number)
            {
                throw new ArgumentOutOfRangeException("Число не может получиться меньше чем 0!");
            }

            var result = new CustomBigUInt(this);

            int carry = 0;
            for (int i = 0; i < number.Digits.Length || carry > 0; i++)
            {
                if (result.Digits.Length <= i)
                {
                    result.Digits.Add(0);
                }

                if (i < number.Digits.Length)
                {
                    result.Digits[i] -= number.Digits[i];
                }

                result.Digits[i] -= carry;

                if (result.Digits[i] < 0)
                {
                    carry = 1;
                    result.Digits[i] += _baseNumber;
                }
                else
                {
                    carry = 0;
                }
            }

            result.Trim();

            return result;
        }
        
        public CustomBigUInt Divide(CustomBigUInt number)
        {
            if (number == 0)
            {
                throw new DivideByZeroException();
            }

            CustomBigUInt left = new CustomBigUInt(0), right = new CustomBigUInt(this);
            while (left < right)
            {
                var middle = (left + right + 1).Divide(2);
                if (middle * number > this)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle;
                }
            }

            left.Trim();

            return left;
        }

        private CustomBigUInt Divide(long number)
        {
            var result = new CustomBigUInt(this);

            int carry = 0;
            for (int i = this.Digits.Length - 1; i >= 0; i--)
            {
                long curr = result.Digits[i] + carry * _baseNumber;
                result.Digits[i] = (int)(curr / number);
                carry = (int)(curr % number);
            }

            result.Trim();

            return result;
        }

        private CustomBigUInt Mod(CustomBigUInt number)
        {
            return this - this / number * number;
        }

#region Операторы сравнения

        public static bool operator < (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            if (firstNumber.Digits.Length < secondNumber.Digits.Length)
            {
                return true;
            }

            if (firstNumber.Digits.Length > secondNumber.Digits.Length)
            {
                return false;
            }

            for (int i = firstNumber.Digits.Length - 1; i >= 0; i--)
            {
                if (firstNumber.Digits[i] < secondNumber.Digits[i])
                {
                    return true;
                }

                if (firstNumber.Digits[i] > secondNumber.Digits[i])
                {
                    return false;
                }
            }

            return false;
        }

        public static bool operator > (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return secondNumber < firstNumber;
        }

        public static bool operator == (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return !(firstNumber > secondNumber) && !(firstNumber < secondNumber);
        }

        public static bool operator != (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return !(firstNumber == secondNumber);
        }

        public static bool operator <= (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return firstNumber < secondNumber || firstNumber == secondNumber;
        }

        public static bool operator >= (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return firstNumber > secondNumber || firstNumber == secondNumber;
        }

#endregion

#region Операторы преобразования

        public static implicit operator CustomBigUInt(long number)
        {
            return new CustomBigUInt(number);
        }

        public static explicit operator CustomBigUInt(string number)
        {
            return new CustomBigUInt(number);
        }

        public static explicit operator long(CustomBigUInt number)
        {
            return Convert.ToInt64(number.ToString());
        }

        public static explicit operator int(CustomBigUInt number)
        {
            return Convert.ToInt32(number.ToString());
        }

        #endregion

#region Математические операторы

        public static CustomBigUInt operator + (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return firstNumber.Add(secondNumber);
        }

        public static CustomBigUInt operator - (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return firstNumber.Minus(secondNumber);
        }

        public static CustomBigUInt operator * (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return firstNumber.Multiply(secondNumber);
        }

        public static CustomBigUInt operator / (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return firstNumber.Divide(secondNumber);
        }

        public static CustomBigUInt operator % (CustomBigUInt firstNumber, CustomBigUInt secondNumber)
        {
            return firstNumber.Mod(secondNumber);
        }
    }

#endregion
}
