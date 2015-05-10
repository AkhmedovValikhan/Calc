# String expression evaluator
###Without using LINQ expression trees
####Добавление нового бинарного оператора:
Для примера добавим класс возведения в степень.

1. Создать класс, наследуемый от абстрактного класса **BinaryExpressionBase**, реализующий интерфейсы *IExpression*, *IBinaryExpression*.

  ```
  public class MyExponentiationExpression : BinaryExpressionBase
      {
          public MyExponentiationExpression()
          {
              Priority = 3;
          }
          public override double Evaluate()
          {
              return Math.Pow(LeftOperand.Evaluate(), RightOperand.Evaluate());
          }
      }
```
2. Зарегеистрировать выражение в методе **RegisterBinaryExpressions()** класса **ExpressionParser**

  ```
  private void RegisterBinaryExpressions()
          {
              Factory.RegisterBinaryExpression("+", typeof(AdditionBinaryExpression));
              Factory.RegisterBinaryExpression("-", typeof(SubtractionBinaryExpression));
              Factory.RegisterBinaryExpression("*", typeof(MultiplicationBinaryExpression));
              Factory.RegisterBinaryExpression("/", typeof(DivisionBinaryExpression));
              
              Factory.RegisterBinaryExpression("^", typeof(MyExponentiationExpression));
          }
  ```
3. Проверка:

  ![Alt text](http://res.cloudinary.com/dfg7fgwtl/image/upload/v1431249052/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA_afimyc.png)
