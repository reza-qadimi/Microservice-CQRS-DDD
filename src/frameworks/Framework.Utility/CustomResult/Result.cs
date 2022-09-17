namespace CustomResult;

public class Result : object
{
	public Result() : base()
	{
		IsSuccess = true;

		_errors = new System.Collections.Generic.List<string>();
		_messages = new System.Collections.Generic.List<string>();
		_successes = new System.Collections.Generic.List<string>();
	}

	public bool IsSuccess { get; private set; }

	private readonly System.Collections.Generic.List<string> _errors;

	public System.Collections.Generic.IReadOnlyList<string> Errors
	{
		get
		{
			return _errors;
		}
	}

	private readonly System.Collections.Generic.List<string> _successes;

	public System.Collections.Generic.IReadOnlyList<string> Successes
	{
		get
		{
			return _successes;
		}
	}

	private readonly System.Collections.Generic.List<string> _messages;

	public System.Collections.Generic.IReadOnlyList<string> Messages
	{
		get
		{
			return _messages;
		}
	}

	public void WithSuccess(string? successMessage)
	{
		successMessage =
			Framework.Utility.String
			.Text.Fix(value: successMessage);

		if (string.IsNullOrWhiteSpace(value: successMessage))
		{
			return;
		}

		if (_successes.Contains(item: successMessage))
		{
			return;
		}

		_successes.Add(item: successMessage);
	}

	public void WithSuccesses
		(System.Collections.Generic.IEnumerable<string> successMessages)
	{
		foreach (var successMessage in successMessages)
		{
			WithSuccess(successMessage: successMessage);
		}
	}

	public void WithError(string? errorMessage)
	{
		IsSuccess = false;

		errorMessage =
			Framework.Utility.String
			.Text.Fix(value: errorMessage);

		if (string.IsNullOrWhiteSpace(value: errorMessage))
		{
			return;
		}

		if (_successes.Contains(item: errorMessage))
		{
			return;
		}

		_successes.Add(item: errorMessage);
	}

	public void WithErrors
		(System.Collections.Generic.IEnumerable<string> errorMessages)
	{
		foreach (var errorMessage in errorMessages)
		{
			WithError(errorMessage: errorMessage);
		}
	}

	public void WithMessage(string? message)
	{
		message =
			Framework.Utility.String
			.Text.Fix(value: message);

		if (string.IsNullOrWhiteSpace(value: message))
		{
			return;
		}

		if (_successes.Contains(item: message))
		{
			return;
		}

		_successes.Add(item: message);
	}

	public void WithMessages
		(System.Collections.Generic.IEnumerable<string> messages)
	{
		foreach (var message in messages)
		{
			WithMessage(message: message);
		}
	}
}

public class Result<T> : Result
{
	public Result() : base()
	{
	}

	public T? Value { get; private set; }

	public void WithValue(T? value)
	{
		Value = value;
	}
}
