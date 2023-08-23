namespace CSharp.Algorithms.Problems.Topics.Stack;

public partial class StackProblem
{
    public static MyQueue CreateQueue()
    {
        return new MyQueue();
    }

    public class MyQueue
    {

        private Stack<int> stackWrite;
        private Stack<int> stackRead;

        public MyQueue()
        {
            stackWrite = new Stack<int>();
            stackRead = new Stack<int>();
        }

        public void Push(int x)
        {
            stackWrite.Push(x);
        }

        public int Pop()
        {
            ShakeUpStacks();
            return stackRead.Pop();
        }

        public int Peek()
        {
            ShakeUpStacks();
            return stackRead.Peek();
        }

        public bool Empty()
        {
            return stackWrite.Count == 0
                   && stackRead.Count == 0;
        }

        void ShakeUpStacks()
        {
            if (stackRead.Count == 0)
            {
                while (stackWrite.Count > 0)
                {
                    stackRead.Push(stackWrite.Pop());
                }
            }
        }
    }

}