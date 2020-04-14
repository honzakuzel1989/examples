using Microsoft.SqlServer.Management.SqlParser.Parser;
using System;
using System.Collections.Generic;

namespace SQLParser
{
    public class TokenInfo
    {
        public int Start { get; internal set; }
        public int End { get; internal set; }
        public bool IsPairMatch { get; internal set; }
        public bool IsExecAutoParamHelp { get; internal set; }
        public string Sql { get; internal set; }
        public Tokens Token { get; internal set; }
    }

    public class Parser
    {
        public List<TokenInfo> ParseSql(string sql)
        {
            ParseOptions parseOptions = new ParseOptions();
            Scanner scanner = new Scanner(parseOptions);

            List<TokenInfo> tokens = new List<TokenInfo>();

            scanner.SetSource(sql, offset: 0);

            Tokens token;
            int state = 0;
            while ((token = (Tokens)scanner.GetNext(ref state, out int start, out int end, out bool isPairMatch, out bool isExecAutoParamHelp))
                != Tokens.EOF)
            {
                TokenInfo tokenInfo = new TokenInfo()
                {
                    Start = start,
                    End = end,
                    IsPairMatch = isPairMatch,
                    IsExecAutoParamHelp = isExecAutoParamHelp,
                    Sql = sql.Substring(start, end - start + 1),
                    Token = token,
                };

                tokens.Add(tokenInfo);
            }

            return tokens;
        }
    }
}
