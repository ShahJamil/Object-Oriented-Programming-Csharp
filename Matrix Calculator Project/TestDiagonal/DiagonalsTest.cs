using CdwcrzHW;
namespace TestDiagonal
{
    [TestClass]
    public class DiagonalsTest
    {
        [TestMethod]
        public void Create()
        {
            Assert.ThrowsException<Diagonals.NegativeSizeException>(() => _ = new Diagonals(0));
            Diagonals a = new(1);
            Assert.AreEqual(a[0, 0], 0);
            Assert.AreEqual(a.Size, 1);

            Diagonals b = new(2);
            Assert.AreEqual(b.Size, 4);

            Diagonals c = new(5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Assert.AreEqual(c[i, j], 0);
                }
            }
            Assert.AreEqual(c.Size, 9);
            Assert.ThrowsException<Diagonals.NegativeSizeException>(() => _ = new Diagonals(-1));
            Diagonals d = new Diagonals(1000);
            Assert.AreEqual(d.Size, 2000);
        }

        [TestMethod]
        public void Change()
        {
            Diagonals c = new(3);
            c[0, 0] = 1;
            c[1, 1] = 1;
            c[2, 2] = 1;

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(c[i, i], 1);
            }

            Assert.AreEqual(c[0, 1], 0);
            Assert.ThrowsException<IndexOutOfRangeException>(() => c[7, 7]);
        }
        
        [TestMethod]
        public void Assignment()
        {
            Diagonals a = new Diagonals(3);
            a[0, 0] = 1;
            a[1, 1] = 2;
            a[2, 2] = 3;
            Diagonals b = new Diagonals(1);
            b = a;
            Assert.IsTrue(a.Equals(b));

            Diagonals c = new Diagonals(2);

             b = new Diagonals(a);


            c = a;
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(c));
            b[0, 0] = 0;
            Assert.IsFalse(a.Equals(b));
            c[0, 0] = 0;
            Assert.IsTrue(a.Equals(b));
            a = b = c;
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(c));
            a = a;
            Assert.IsTrue(a.Equals(a));
        }
        [TestMethod]
        public void Add()
        {
            Diagonals a = new(3);
            Diagonals b = new(3);
            Diagonals zero = new(3);
            Diagonals d = new(2);
            Diagonals c;
            a[0, 0] = 1;
            a[1, 1] = 1;
            a[2, 2] = 1;

            b[0, 0] = 42;
            b[1, 1] = 0;
            b[2, 2] = 0;

            c = a + b;

            Assert.AreEqual(c[0, 0], 43);
            Assert.AreEqual(c[1, 1], 1);
            Assert.IsTrue(a.Equals(a + zero));
            Assert.IsTrue(a.Equals(zero + a));
            Assert.IsTrue((a + b).Equals(b + a));
            Assert.IsTrue(((a + b) + c).Equals(a + (b + c)));

            Assert.ThrowsException<Diagonals.DifferentSizeException>(() => a + d);
            Assert.ThrowsException<Diagonals.DifferentSizeException>(() => b + d);

        }

        [TestMethod]
        public void Mul()
        {
            Diagonals a = new(3);
            Diagonals b = new(3);
            Diagonals d = new(2);
            Diagonals zero = new(3);
            Diagonals c;
            Diagonals iden = new(3);
            for (int i = 0; i < iden.Size/2+1; i++)
            {
                iden.vector[i] = 1;
            }
                
            a[0, 0] = 1;
            a[1, 1] = 2;
            a[2, 2] = 3;
            a[0, 2] = 4;
            a[2, 0] = 5;

            b[0, 0] = 1;
            b[1, 1] = 2;
            b[2, 2] = 3;
            b[0, 2] = 4;
            b[2, 0] = 5;

            c = a * b;

            Assert.AreEqual(c[0, 0], 21);
            Assert.AreEqual(c[1, 1], 4);

            Assert.IsTrue(zero.Equals(a * zero));
            Assert.IsTrue(c.Equals(a * b));
            Assert.IsTrue((a * (b * c)).Equals((a * b) * c));
            Assert.IsTrue((b * c).Equals(c * b));

            Assert.ThrowsException<Diagonals.DifferentSizeException>(() => a * d);
            Assert.ThrowsException<Diagonals.DifferentSizeException>(() => b * d);
            
            Assert.IsTrue(a.Equals(a * iden));
        }

        [TestMethod]
        public void SetMatrix()
        {
            List<double> vec = new List<double>() { 1, 2, 3, 4, 5 };
            Diagonals a = new Diagonals(3);
            Diagonals b = new Diagonals(2);

            Assert.AreEqual(a[0, 0], 0);
            Assert.AreEqual(a[1, 1], 0);
            Assert.AreEqual(a[2, 2], 0);
            Assert.AreEqual(a[0, 2], 0);
            Assert.AreEqual(a[2, 0], 0);


            a.Set(vec);
            Assert.AreEqual(a[0, 0], 1);
            Assert.AreEqual(a[1, 1], 2);
            Assert.AreEqual(a[2, 2], 3);
            Assert.AreEqual(a[0, 2], 4);
            Assert.AreEqual(a[2, 0], 5);

            Assert.ThrowsException<Diagonals.DifferentSizeException>(() => b.Set(vec));
        }
    }
}