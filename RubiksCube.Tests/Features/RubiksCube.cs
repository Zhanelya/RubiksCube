using Xunit;

namespace RubiksCube.Tests.Features
{
    public class RubiksCube
    {
        [Fact]
        public void TestInitialState()
        {
            var rubiksCode = new global::RubiksCube.Features.RubiksCube.RubiksCube();
            Assert.Equal("      www \r\n      www \r\n      www \r\n ooo  ggg  rrr  bbb \r\n ooo  ggg  rrr  bbb \r\n ooo  ggg  rrr  bbb \r\n      yyy \r\n      yyy \r\n      yyy \r\n", 
                rubiksCode.PrintState());
        }

        [Fact]
        public void TestFinalState()
        {
            var rubiksCode = new global::RubiksCube.Features.RubiksCube.RubiksCube();
            rubiksCode.ApplyRequiredFaceRotations();
            Assert.Equal("      rog \r\n      bww \r\n      bbb \r\n gyy  orr  ybo  ybw \r\n oog  ogw  rrw  oby \r\n bgo  www  oyr  yyw \r\n      ggb \r\n      ryr \r\n      rgg \r\n",
                rubiksCode.PrintState());
        }
    }
}
