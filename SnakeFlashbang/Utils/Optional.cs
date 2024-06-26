﻿namespace LcEmotes2AndKnucklesFeaturingDante.Utils;

public readonly struct Optional<T>
{
    private readonly T? _value;
    public bool HasValue { get; } = false;

    private Optional(T value)
    {
        _value = value;
        HasValue = true;
    }

    public bool TryGetValue(out T? value)
    {
        value = _value;
        return HasValue;
    }
    
    public static Optional<T> Some(T value) => new(value);
    
    public static Optional<T> None() => new();
}