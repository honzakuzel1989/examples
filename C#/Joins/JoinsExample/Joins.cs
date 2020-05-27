using System.Collections.Generic;

namespace System.Linq
{
    public static class Joins
    {
        public static IEnumerable<(TLeft l, TRight r)> InnerJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> on)
        {
            foreach (var l in left)
            {
                foreach (var r in right)
                {
                    if (on(l, r))
                    {
                        yield return (l, r);
                    }
                }
            }
        }

        public static IEnumerable<(TLeft l, TRight r)> LeftJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TRight> nullObjectFactory,
            Func<TLeft, TRight, bool> on)
        {
            foreach (var l in left)
            {
                var founded = false;
                foreach (var r in right)
                {
                    if (on(l, r))
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
            Func<TLeft, TRight, bool> on)
        {
            return LeftJoin(left, right, () => nullObject, on);
        }

        public static IEnumerable<(TLeft l, TRight r)> LeftJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> on) where TRight : new()
        {
            return LeftJoin(left, right, new TRight(), on);
        }

        public static IEnumerable<(TLeft l, TRight r)> LeftJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> on,
            Func<TLeft, TRight, bool> where) where TRight : new()
        {
            return LeftJoin(left, right, new TRight(), on).Where(r => where(r.l, r.r));
        }

        public static IEnumerable<(TLeft l, TRight r)> RightJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            Func<TLeft> nullObjectFactory,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> on)
        {
            foreach (var r in right)
            {
                var founded = false;
                foreach (var l in left)
                {
                    if (on(l, r))
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
            Func<TLeft, TRight, bool> on)
        {
            return RightJoin(left, () => nullObject, right, on);
        }

        public static IEnumerable<(TLeft l, TRight r)> RightJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> on) where TLeft : new()
        {
            return RightJoin(left, new TLeft(), right, on);
        }

        public static IEnumerable<(TLeft l, TRight r)> RightJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> on,
            Func<TLeft, TRight, bool> where) where TLeft : new()
        {
            return RightJoin(left, new TLeft(), right, on).Where(r => where(r.l, r.r));
        }

        public static IEnumerable<(TLeft l, TRight r)> OuterJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            Func<TLeft> lNullObjectFactory,
            IEnumerable<TRight> right,
            Func<TRight> rNullObjectFactory,
            Func<TLeft, TRight, bool> on)
        {
            return LeftJoin(left, right, rNullObjectFactory, on)
                .Concat(RightJoin(left, lNullObjectFactory, right, on));
        }

        public static IEnumerable<(TLeft l, TRight r)> OuterJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            TLeft lNullObject,
            IEnumerable<TRight> right,
            TRight rNullObject,
            Func<TLeft, TRight, bool> on)
        {
            return OuterJoin(left, () => lNullObject, right, () => rNullObject, on);
        }

        public static IEnumerable<(TLeft l, TRight r)> OuterJoin<TLeft, TRight>(this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TRight, bool> on)
        {
            return OuterJoin(left, default(TLeft), right, default(TRight), on);
        }
    }
}
