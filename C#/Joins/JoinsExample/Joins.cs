using System.Collections.Generic;

namespace System.Linq
{
    public static class Joins
    {
        public static IEnumerable<(TLeft l, TRight r)> InnerJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> where)
        {
            foreach (var l in left)
            {
                foreach (var r in right)
                {
                    if (where(l, r))
                    {
                        yield return (l, r);
                    }
                }
            }
        }

        public static IEnumerable<(TLeft l, TRight r)> LeftJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TRight> nullObjectFactory,
            Func<TLeft, TRight, bool> where)
        {
            foreach (var l in left)
            {
                var founded = false;
                foreach (var r in right)
                {
                    if (where(l, r))
                    {
                        yield return (l, r);
                        founded = true;
                    }
                }

                if (!founded)
                    yield return (l, nullObjectFactory());
            }
        }

        public static IEnumerable<(TLeft l, TRight r)> LeftJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            TRight nullObject,
            Func<TLeft, TRight, bool> where)
        {
            return LeftJoin(left, right, () => nullObject, where);
        }

        public static IEnumerable<(TLeft l, TRight r)> LeftJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> where)
        {
            return LeftJoin(left, right, default(TRight), where);
        }

        public static IEnumerable<(TLeft l, TRight r)> RightJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            Func<TLeft> nullObjectFactory,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> where)
        {
            foreach (var r in right)
            {
                var founded = false;
                foreach (var l in left)
                {
                    if (where(l, r))
                    {
                        yield return (l, r);
                        founded = true;
                    }
                }

                if (!founded)
                    yield return (nullObjectFactory(), r);
            }
        }

        public static IEnumerable<(TLeft l, TRight r)> RightJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            TLeft nullObject,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> where)
        {
            return RightJoin(left, () => nullObject, right, where);
        }

        public static IEnumerable<(TLeft l, TRight r)> RightJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> where)
        {
            return RightJoin(left, default(TLeft), right, where);
        }

        public static IEnumerable<(TLeft l, TRight r)> OuterJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            Func<TLeft> lNullObjectFactory,
            IEnumerable<TRight> right,
            Func<TRight> rNullObjectFactory,
            Func<TLeft, TRight, bool> where)
        {
            return LeftJoin(left, right, rNullObjectFactory, where)
                .Concat(RightJoin(left, lNullObjectFactory, right, where));
        }

        public static IEnumerable<(TLeft l, TRight r)> OuterJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            TLeft lNullObject,
            IEnumerable<TRight> right,
            TRight rNullObject,
            Func<TLeft, TRight, bool> where)
        {
            return OuterJoin(left, () => lNullObject, right, () => rNullObject, where);
        }

        public static IEnumerable<(TLeft l, TRight r)> OuterJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> where)
        {
            return OuterJoin(left, default(TLeft), right, default(TRight), where);
        }
    }
}
