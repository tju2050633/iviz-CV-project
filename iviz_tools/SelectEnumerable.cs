using System;
using System.Collections;
using System.Collections.Generic;

namespace Iviz.Tools;

public readonly struct SelectEnumerable<TC, TA, TB> : IReadOnlyList<TB>, ICollection<TB> where TC : IReadOnlyList<TA>
{
    readonly TC a;
    readonly Func<TA, TB> f;

    public struct Enumerator : IEnumerator<TB>
    {
        readonly TC a;
        readonly Func<TA, TB> f;
        int index;

        internal Enumerator(TC na, Func<TA, TB> nf) => (a, f, index) = (na, nf, -1);
        public bool MoveNext() => ++index < a.Count;
        public void Reset() => index = -1;
        public TB Current => f(a[index]);
        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }

    public int Count => a.Count;
    public TB this[int index] => f(a[index]);
    
    public SelectEnumerable(TC a, Func<TA, TB> f)
    {
        this.a = a;
        this.f = f;
    }

    public Enumerator GetEnumerator() => new(a, f);

    public void CopyTo(TB[] array, int arrayIndex) => CopyTo(array.AsSpan()[arrayIndex..]);

    public TB[] ToArray()
    {
        if (a.Count == 0)
        {
            return Array.Empty<TB>();
        }

        TB[] array = new TB[a.Count];
        CopyTo(array);
        return array;
    }

    public List<TB> ToList()
    {
        List<TB> array = new(a.Count);
        foreach (int i in ..a.Count)
        {
            array.Add(f(a[i]));
        }

        return array;
    }

    public bool All(Func<TB, bool> predicate)
    {
        foreach (int i in ..a.Count)
        {
            if (!predicate(f(a[i])))
            {
                return false;
            }
        }

        return true;
    }

    public bool Any(Func<TB, bool> predicate)
    {
        foreach (int i in ..a.Count)
        {
            if (predicate(f(a[i])))
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(Span<TB> span)
    {
        foreach (int i in ..a.Count)
        {
            span[i] = f(a[i]);
        }
    }


    void ICollection<TB>.Add(TB item) => throw new NotSupportedException();
    void ICollection<TB>.Clear() => throw new NotSupportedException();
    bool ICollection<TB>.Contains(TB item) => throw new NotSupportedException();
    bool ICollection<TB>.Remove(TB item) => throw new NotSupportedException();
    IEnumerator<TB> IEnumerable<TB>.GetEnumerator() => GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    bool ICollection<TB>.IsReadOnly => true;
}