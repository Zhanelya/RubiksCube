namespace RubiksCube.Features.RubiksCube
{
    partial class RubiksCube
    {
        private class StatePrinter
        {
            private readonly char[,,] _state;

            public StatePrinter(RubiksCube cube)
            {
                _state = cube._state;
            }

            public string PrintState()
            {
                return PrintUpFace() + PrintLeftFrontRightAndBackFaces() + PrintDownFace();
            }

            private string PrintUpFace()
            {
                return PrintEmptySpace() + PrintStateForGivenFaceAndRow(Face.Up, 0) + PrintNewLine() +
                       PrintEmptySpace() + PrintStateForGivenFaceAndRow(Face.Up, 1) + PrintNewLine() +
                       PrintEmptySpace() + PrintStateForGivenFaceAndRow(Face.Up, 2) + PrintNewLine();
            }

            private string PrintEmptySpace()
            {
                return "     ";
            }

            private string PrintStateForGivenFaceAndRow(Face face, int row)
            {
                char[] chars =
                    {' ', _state[(int) face, 0, row], _state[(int) face, 1, row], _state[(int) face, 2, row], ' '};
                return new string(chars);
            }

            private string PrintNewLine()
            {
                return "\r\n";
            }

            private string PrintLeftFrontRightAndBackFaces()
            {
                return PrintStateForGivenFaceAndRow(Face.Left, 0) + PrintStateForGivenFaceAndRow(Face.Front, 0) +
                       PrintStateForGivenFaceAndRow(Face.Right, 0) + PrintStateForGivenFaceAndRow(Face.Back, 0) +
                       PrintNewLine() +
                       PrintStateForGivenFaceAndRow(Face.Left, 1) + PrintStateForGivenFaceAndRow(Face.Front, 1) +
                       PrintStateForGivenFaceAndRow(Face.Right, 1) + PrintStateForGivenFaceAndRow(Face.Back, 1) +
                       PrintNewLine() +
                       PrintStateForGivenFaceAndRow(Face.Left, 2) + PrintStateForGivenFaceAndRow(Face.Front, 2) +
                       PrintStateForGivenFaceAndRow(Face.Right, 2) + PrintStateForGivenFaceAndRow(Face.Back, 2) +
                       PrintNewLine();
            }

            private string PrintDownFace()
            {
                return PrintEmptySpace() + PrintStateForGivenFaceAndRow(Face.Down, 0) + PrintNewLine() +
                       PrintEmptySpace() + PrintStateForGivenFaceAndRow(Face.Down, 1) + PrintNewLine() +
                       PrintEmptySpace() + PrintStateForGivenFaceAndRow(Face.Down, 2) + PrintNewLine();
            }
        }
    }
}