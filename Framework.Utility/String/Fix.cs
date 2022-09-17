namespace Framework.Utility.String;

public static class Fix : object
{
	static Fix()
	{
	}

	public static string? FixText(string? value)
	{
		if (value == null)
		{
			return value;
		}

		value = value.Trim();

		if (value == null)
		{
			return value;
		}

		while (value.Contains(value: "  "))
		{
			value =
				value.Replace
				(oldValue: "  ", newValue: " ");
		}

		return value;
	}
}
