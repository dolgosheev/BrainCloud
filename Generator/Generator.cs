using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;

namespace Generator
{
    public class Generator
    {
        
        public string Generate(byte length,
            bool digits = true,
            bool upperCase = true,
            bool lowerCase = true,
            params char[] additionalSymbols)
        {

            Span<int> generalSpan = new Span<int>( );
            
            if (digits) /* 0-9 */
                UpdateResult(ref generalSpan, 48, 10);
                
            if (upperCase) /* A-Z */
                UpdateResult(ref generalSpan, 65, 26);

            if (lowerCase) /* a-z */
                UpdateResult(ref generalSpan, 97, 26);

            if (additionalSymbols.Length > 0) /* your symbols */
            {
                var swapedSpan = additionalSymbols.Select(x => (int) x).ToArray().AsSpan();
                UpdateResult(ref generalSpan,ref swapedSpan);
                swapedSpan.Clear();
            }
            
            if (generalSpan.Length <= 0)
                return string.Empty;
            
            return new string(
                Enumerable
                    .Repeat(generalSpan.ToArray().Select(x => (char) x).Distinct().ToArray(), length)
                    .Select(x => x[new Random().Next(x.Length)])
                    .ToArray()
            );
        }
        
        public string GenerateTrivial(byte length,
            bool digits = true,
            bool upperCase = true,
            bool lowerCase = true,
            params char[] additionalSymbols)
        {
            IEnumerable<int> asciiList = new int[] { };

            if (digits) /* 0-9 */
                asciiList = asciiList.Concat(Enumerable.Range(48, 10));

            if (upperCase) /* A-Z */
                asciiList = asciiList.Concat(Enumerable.Range(65, 26));

            if (lowerCase) /* a-z */
                asciiList = asciiList.Concat(Enumerable.Range(97, 26));

            if (additionalSymbols.Length > 0) /* your symbols */
                asciiList = asciiList.Concat(additionalSymbols.Select(x => (int) x));

            var asciiArrayByParams = asciiList as int[] ?? asciiList.ToArray();

            if (asciiArrayByParams.Length <= 0)
                return string.Empty;

            return new string(
                Enumerable
                    .Repeat(asciiArrayByParams.Select(x => (char) x).Distinct().ToArray(), length)
                    .Select(x => x[new Random().Next(x.Length)])
                    .ToArray()
            );
        }
        
        private void UpdateResult(ref Span<int> span, int asciiCode, int asciiCodeLength)
        {
            var newSpan = Enumerable.Range(asciiCode, asciiCodeLength).ToArray().AsSpan();
            UpdateResult(ref span,ref newSpan);
        }

        private void UpdateResult(ref Span<int> span,ref Span<int> newSpan)
        {
            Span<int> generalSpanCopy = new Span<int>( new int[span.Length + newSpan.Length] );
                
            span.CopyTo(generalSpanCopy);
            newSpan.CopyTo(generalSpanCopy.Slice(span.Length,newSpan.Length));
                
            unsafe
            {
                fixed (int* ptr = generalSpanCopy)
                {
                    span = new Span<int>(ptr, generalSpanCopy.Length);
                }
            }
        }
    }
}