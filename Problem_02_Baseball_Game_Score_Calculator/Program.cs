using static System.Console;

string[] ops1 = { "5", "2", "C", "D", "+" };
string[] ops2 = { "5", "-2", "4", "C", "D", "9", "+", "+" };
string[] ops3 = { "1" };

WriteLine(CalculatePoints(ops1));
WriteLine(CalculatePoints(ops2));
WriteLine(CalculatePoints(ops3));


static int CalculatePoints(IEnumerable<string> ops)
{
    Stack<int> stack = new();

    foreach (var op in ops)
    {
        switch (op)
        {
            case "+":
            {
                int top = stack.Pop();
                int newTop = top + stack.Peek();
                stack.Push(top);
                stack.Push(newTop);
                break;
            }
            case "C":
                stack.Pop();
                break;
            case "D":
                stack.Push(2 * stack.Peek());
                break;
            default:
            {
                if (int.TryParse(op, out int intOp))
                    stack.Push(intOp);
                break;
            }
        }
    }

    return stack.Aggregate(0, (current, score) => current + score);
}