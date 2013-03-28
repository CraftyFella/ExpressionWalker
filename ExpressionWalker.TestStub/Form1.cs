using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressionWalker.TestStub
{
    public partial class Form1 : Form
    {
        private readonly ExpressionWalker _expressionWalker;

        public Form1()
        {
            InitializeComponent();
            _expressionWalker = new ExpressionWalker();
            _expressionWalker.Subscribe(new TextBoxWriter(this));
        }

        private void buttonSimpleExpression_Click(object sender, EventArgs e)
        {
            Expression<Func<int, int>> simpleExpression = x => x * x;

            _expressionWalker.Walk(simpleExpression);
        }

        private void buttonMethodCallExpression_Click(object sender, EventArgs e)
        {
            Expression<Action<int, int>> methodCallExpression = (x, y) => Console.WriteLine("x {0}, y{1}", x, y);

            _expressionWalker.Walk(methodCallExpression);
        }
    }

    internal class TextBoxWriter : IObserver<ExpressionInfo>
    {
        private readonly Form1 _form1;

        public TextBoxWriter(Form1 form1)
        {
            _form1 = form1;
        }

        public void OnNext(ExpressionInfo info)
        {
            var line = string.Format("{0}{1} {2}", Enumerable.Range(0, info.Depth).Aggregate("", (s, i) => s += "\t"), info.ExpressionType, info.Value);
            _form1.inputExpression.Text += line + Environment.NewLine;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
