using System;
using System.Linq.Expressions;
using System.Text;

namespace MyApp.QueryBuilder
{
    public class ExpressionPrinter : ExpressionVisitor
    {
        private readonly StringBuilder _sb = new();

        public string Print(Expression expr)
        {
            _sb.Clear();
            Visit(expr);
            return _sb.ToString();
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert || node.NodeType == ExpressionType.ConvertChecked)
            {
                // Se for cast explícito para int, imprime (int)
                if (node.Type == typeof(int))
                {
                    _sb.Append("(int)");
                    Visit(node.Operand);
                    return node;
                }

                // Se for cast automático (ex.: double), ignora
                return Visit(node.Operand);
            }

            if (node.NodeType == ExpressionType.Negate || node.NodeType == ExpressionType.NegateChecked)
            {
                _sb.Append("-");
                Visit(node.Operand);
                return node;
            }

            return base.VisitUnary(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null)
            {
                Visit(node.Expression);
                _sb.Append(".");
            }
            else
            {
                // 👇 se for membro estático, imprime o tipo (DateTime, Math, etc.)
                _sb.Append(node.Member.DeclaringType?.Name);
                _sb.Append(".");
            }

            _sb.Append(node.Member.Name);
            return node;
        }


        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Object != null)
                Visit(node.Object);
            else
                _sb.Append(node.Method.DeclaringType?.Name);

            _sb.Append($".{node.Method.Name}(");
            for (int i = 0; i < node.Arguments.Count; i++)
            {
                if (i > 0) _sb.Append(", ");
                Visit(node.Arguments[i]);
            }
            _sb.Append(")");
            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            _sb.Append("(");
            Visit(node.Left);

            // operador
            string op = node.NodeType switch
            {
                ExpressionType.Add => " + ",
                ExpressionType.Subtract => " - ",
                ExpressionType.Multiply => " * ",
                ExpressionType.Divide => " / ",
                ExpressionType.Modulo => " % ",
                ExpressionType.AndAlso => " && ",
                ExpressionType.OrElse => " || ",
                ExpressionType.Equal => " == ",
                ExpressionType.NotEqual => " != ",
                ExpressionType.GreaterThan => " > ",
                ExpressionType.GreaterThanOrEqual => " >= ",
                ExpressionType.LessThan => " < ",
                ExpressionType.LessThanOrEqual => " <= ",
                _ => $" {node.NodeType} "
            };
            _sb.Append(op);

            Visit(node.Right);
            _sb.Append(")");

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value is string s)
                _sb.Append($"\"{s}\"");
            else if (node.Value == null)
                _sb.Append("null");
            else
                _sb.Append(node.Value);
            return node;
        }
    }
}