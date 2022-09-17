namespace Framework.Utility.String;

public static class Text : object
{
	static Text()
	{
	}

	public static string? Fix(string? value)
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
