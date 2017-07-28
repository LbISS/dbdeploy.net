namespace Net.Sf.Dbdeploy.Configuration
{
	using Net.Sf.Dbdeploy.Database;
	using System;

	/// <summary>
	/// Parser for command line arguments.
	/// </summary>
	public static class Parser
    {
        /// <summary>
        /// Parses the type of the delimiter.
        /// </summary>
        /// <param name="value">The string to parse.</param>
        /// <returns>The parsed value or default.</returns>
        public static IDelimiterType ParseDelimiterType(string value)
        {
            switch ((value ?? string.Empty).ToUpperInvariant())
            {
                case "ROW":
                    return new RowDelimiter();

                case "NORMAL":
                default:
                    return new NormalDelimiter();
            }
        }

        /// <summary>
        /// Parses the line ending.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>The parsed value.</returns>
        public static string ParseLineEnding(string value)
        {
            switch ((value ?? string.Empty).ToUpperInvariant())
            {
                case "CR":
                    return LineEnding.Cr;

                case "CRLF":
                    return LineEnding.CrLf;

                case "LF":
                    return LineEnding.Lf;

                default:
                case "PLATFORM":
                    return LineEnding.Platform;
            }
        }

		/// <summary>
		/// Parses the type of the int.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static int? ParseIntType(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				return null;

			int res;

			var success = Int32.TryParse(value, out res);

			if (success)
				return res;

			return null;
		}
	}
}