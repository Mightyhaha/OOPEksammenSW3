function Scanner( ) returns Token
while s.peek( ) = blank do call s.advance( )
if s.EOF( )
then ans.type ← $
else
if s.peek( ) ∈ { 0, 1,..., 9 }
then ans ← ScanDigits( )
else
ch ← s.advance( )
switch (ch)
case { a, b,..., z }−{ i, f, p }
ans.type ← id
ans.val ← ch
case f
ans.type ← floatdcl
case i
ans.type ← intdcl
case p
ans.type ← print
case =
ans.type ← assign
case +
ans.type ← plus
case -
ans.type ← minus
case de f ault
call LexicalError( )
return (ans)
end