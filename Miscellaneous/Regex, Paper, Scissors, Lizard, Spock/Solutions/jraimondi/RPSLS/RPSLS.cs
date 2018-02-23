using System.Text.RegularExpressions;
using Xunit;

namespace RPSLS
{
    public class Rpsls
    {
        /*
         * | Regex | Matches | Doesn't match |
         * |-------|---------|---------------|
         * | R     | L, S    | V, P          |
         * | L     | V, P    | S, R          |
         * | V     | S, R    | P, L          |
         * | S     | P, L    | R, V          |
         * | P     | R, V    | L, S          |
         * */

        private Regex R = GetRegex(@"R$|^[SL]");
        private Regex L = GetRegex(@"L$|^[VP]");
        private Regex V = GetRegex(@"V$|^[SR]");
        private Regex S = GetRegex(@"S$|^[PL]");
        private Regex P = GetRegex(@"P$|^[RV]");

        [Fact]
        public void R_Matches_L() => AssertMatches(R, L);

        [Fact]
        public void R_Matches_S() => AssertMatches(R, S);

        [Fact]
        public void R_DoesNotMatch_V() => AssertDoesNotMatch(R, V);

        [Fact]
        public void R_DoesNotMatch_P() => AssertDoesNotMatch(R, P);

        [Fact]
        public void L_Matches_V() => AssertMatches(L, V);

        [Fact]
        public void L_Matches_P() => AssertMatches(L, P);

        [Fact]
        public void L_DoesNotMatch_S() => AssertDoesNotMatch(L, S);

        [Fact]
        public void L_DoesNotMatch_R() => AssertDoesNotMatch(L, R);

        [Fact]
        public void V_Matches_S() => AssertMatches(V, S);

        [Fact]
        public void V_Matches_R() => AssertMatches(V, R);

        [Fact]
        public void V_DoesntMatch_P() => AssertDoesNotMatch(V, P);

        [Fact]
        public void V_DoesntMatch_L() => AssertDoesNotMatch(V, L);

        [Fact]
        public void S_Matches_P() => AssertMatches(S, P);

        [Fact]
        public void S_Matches_L() => AssertMatches(S, L);

        [Fact]
        public void S_DoesntMatch_R() => AssertDoesNotMatch(S, R);

        [Fact]
        public void S_DoesntMatch_V() => AssertDoesNotMatch(S, V);

        [Fact]
        public void P_Matches_R() => AssertMatches(P, R);

        [Fact]
        public void P_Matches_V() => AssertMatches(P, V);

        [Fact]
        public void P_DoesntMatch_L() => AssertDoesNotMatch(P, L);

        [Fact]
        public void P_DoesntMatch_S() => AssertDoesNotMatch(P, S);

        private static Regex GetRegex(string regexContents)
            => new Regex(regexContents);

        private void AssertMatches(Regex regexToRun, Regex regexToEvaluateAsText)
            => Assert.Matches(regexToRun, regexToEvaluateAsText.ToString());

        private void AssertDoesNotMatch(Regex regexToRun, Regex regexToEvaluateAsText)
            => Assert.DoesNotMatch(regexToRun, regexToEvaluateAsText.ToString());
    }
}
