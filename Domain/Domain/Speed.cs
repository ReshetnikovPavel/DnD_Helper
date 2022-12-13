﻿using Infrastructure;

namespace Domain;

public class Speed : ValueType<Speed>, IHaveValue, IDndObject
{
	public Speed(int value)
	{
		Value = value;
	}
	public int Value { get; private set; }

    public void Add(Speed value)
    {
		Value += value.Value;
    }

}