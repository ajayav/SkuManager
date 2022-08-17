namespace SkuManager
{
    public static class MakeSafe
    {
        #region STRING CONVERSION

        /// <summary>
        /// Safely convert object to string.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <returns>The output string.</returns>
        public static string ToSafeString(object inputValue)
        {
            if (inputValue == null || inputValue == DBNull.Value)
            {
                return string.Empty;
            }

            return inputValue.ToString();
        }

        /// <summary>
        /// Safely convert object to string or null.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <returns>The output string or NULL.</returns>
        public static string ToSafeStringOrNull(object inputValue)
        {
            if (inputValue == null || inputValue == DBNull.Value)
            {
                return null;
            }

            return inputValue.ToString();
        }

        /// <summary>
        /// Convert object to string or null.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <returns>The output string or NULL.</returns>
        public static string ToStringOrNull(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return null;
            }

            return inputValue;
        }



        #endregion

        #region INTEGER CONVERSION

        /// <summary>
        /// Safely convert object to integer-32 with default value.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The output integer-32.</returns>
        public static int ToSafeInt32(object inputValue, int defaultValue)
        {
            int result;

            if (inputValue == null || inputValue == DBNull.Value || !int.TryParse(inputValue.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }
        public static uint ToSafeUInt32(object inputValue, uint defaultValue = 0)
        {
            uint result;

            if (inputValue == null || inputValue == DBNull.Value || !uint.TryParse(inputValue.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }


        public static long ToSafeLong(object inputValue)
        {
            return ToSafeLong(inputValue, 0);
        }
        public static short ToSafeShort(object inputValue)
        {
            return ToSafeShort(inputValue, 0);
        }
        private static long ToSafeLong(object inputValue, long defaultValue)
        {
            long result;

            if (inputValue == null || inputValue == DBNull.Value || !long.TryParse(inputValue.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }
        private static short ToSafeShort(object inputValue, short defaultValue)
        {
            short result;

            if (inputValue == null || inputValue == DBNull.Value || !short.TryParse(inputValue.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }


        /// <summary>
        /// Safely convert object to integer-32.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <returns>The output integer-32.</returns>
        public static int ToSafeInt32(object inputValue)
        {
            return ToSafeInt32(inputValue, 0);
        }

        #endregion

        #region DATETIME CONVERSION

        /// <summary>
        /// Safely convert object to date-time.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <returns>The output date-time.</returns>
        public static DateTime ToSafeDateTime(object inputValue)
        {
            try
            {
                DateTime result;

                if (inputValue == null || inputValue == DBNull.Value || !DateTime.TryParse(inputValue.ToString(), out result))
                {
                    return DateTime.MinValue;
                }

                return result.ToLocalTime();
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime? ToSafeNullableDateTime(object inputValue)
        {
            try
            {
                DateTime result;

                if (inputValue == null || inputValue == DBNull.Value || !DateTime.TryParse(inputValue.ToString(), out result))
                {
                    return null;
                }

                return result;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
        #endregion

        #region BOOLEAN CONVERSION

        /// <summary>
        /// Safely convert object to boolean.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <returns>The output boolean.</returns>
        public static bool ToSafeBool(object inputValue)
        {
            if (inputValue == null || inputValue == DBNull.Value || inputValue.ToString() == "0")
            {
                return false;
            }

            if (inputValue.ToString() == "1")
            {
                return true;
            }

            bool result;

            if (bool.TryParse(inputValue.ToString(), out result))
            {
                return result;
            }

            return false;
        }

        #endregion

        #region DECIMAL CONVERSION

        /// <summary>
        /// Safely convert object to decimal.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <returns>The output decimal.</returns>
        public static decimal ToSafeDecimal(object inputValue)
        {
            return ToSafeDecimal(inputValue, 0m);
        }

        /// <summary>
        /// Safely convert object to decimal with default value.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The output decimal.</returns>
        public static decimal ToSafeDecimal(object inputValue, decimal defaultValue)
        {
            decimal result;

            if (inputValue == null || inputValue == DBNull.Value || !decimal.TryParse(inputValue.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }
        public static float ToSafeFloat(object inputValue)
        {
            return ToSafeFloat(inputValue, 0f);
        }

        /// <summary>
        /// Safely convert object to decimal with default value.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The output decimal.</returns>
        public static float ToSafeFloat(object inputValue, float defaultValue)
        {
            float result;

            if (inputValue == null || inputValue == DBNull.Value || !float.TryParse(inputValue.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }
        #endregion

        public static Guid ToSafeGuid(object inputValue)
        {
            Guid result;

            if (inputValue == null || inputValue == DBNull.Value || !Guid.TryParse(inputValue.ToString(), out result))
            {
                return new Guid();
            }

            return result;
        }
    }
}
