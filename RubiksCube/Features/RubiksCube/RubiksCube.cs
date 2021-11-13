using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RubiksCube.Tests")]
namespace RubiksCube.Features.RubiksCube
{
    partial class RubiksCube
    {
        private char[,,] _state;
        private enum Face { Up, Left, Front, Right, Back, Down };
        private readonly char[] colours = { 'w', 'o', 'g', 'r', 'b', 'y' };

        public RubiksCube()
        {
            _state = new char[6,3,3];
            InitialiseCube();
        }

        private void InitialiseCube()
        {
            for (var face = 0; face < colours.Length; face++)
            {
                InitializeFaceWithCubeletsOfTheSameColour(face, colours[face]);
            }
        }

        private void InitializeFaceWithCubeletsOfTheSameColour(int face, char colour)
        {
            for (var column = 0; column < 3; column++)
            {
                for (var row = 0; row < 3; row++)
                {
                    _state[face, column, row] = colour;
                }
            }
        }
        
        public void ApplyRequiredFaceRotations()
        {
            RotateFrontFaceClockwise();
            RotateRightFaceAntiClockwise();
            RotateUpFaceClockwise();
            RotateBackFaceAntiClockwise();
            RotateLeftFaceClockwise();
            RotateDownFaceAnticlockwise();
        }

        private void RotateFrontFaceClockwise()
        {
            var newState = (char[,,])_state.Clone();
            ShiftRowFromOneFaceToColumnOfAnotherFace(Face.Left, 2, Face.Down,0, newState);
            ShiftColumnFromOneFaceToRowOfAnotherFace(Face.Up, 2, Face.Left, 2, newState);
            ShiftRowFromOneFaceToColumnOfAnotherFace(Face.Right, 0, Face.Up, 2, newState);
            ShiftColumnFromOneFaceToRowOfAnotherFace(Face.Down, 0, Face.Right, 0, newState);
            RotateFaceClockwise(Face.Front, newState);
            _state = newState;
        }

        private void ShiftRowFromOneFaceToColumnOfAnotherFace(Face faceTo, int columnTo, Face faceFrom, int rowFrom, char[,,] newState)
        {
            newState[(int)faceTo, columnTo, 2] = _state[(int)faceFrom, 2, rowFrom];
            newState[(int)faceTo, columnTo, 1] = _state[(int)faceFrom, 1, rowFrom];
            newState[(int)faceTo, columnTo, 0] = _state[(int)faceFrom, 0, rowFrom];
        }

        private void ShiftColumnFromOneFaceToRowOfAnotherFace(Face faceTo, int rowTo, Face faceFrom, int columnFrom, char[,,] newState)
        {
            newState[(int)faceTo, 2, rowTo] = _state[(int)faceFrom, columnFrom, 2];
            newState[(int)faceTo, 1, rowTo] = _state[(int)faceFrom, columnFrom, 1];
            newState[(int)faceTo, 0, rowTo] = _state[(int)faceFrom, columnFrom, 0];
        }

        private void RotateFaceClockwise(Face face, char[,,] newState)
        {
            newState[(int)face, 0, 0] = _state[(int)face, 0, 2];
            newState[(int)face, 1, 0] = _state[(int)face, 0, 1];
            newState[(int)face, 2, 0] = _state[(int)face, 0, 0];
            newState[(int)face, 2, 1] = _state[(int)face, 1, 0];
            newState[(int)face, 2, 2] = _state[(int)face, 2, 0];
            newState[(int)face, 1, 2] = _state[(int)face, 2, 1];
            newState[(int)face, 0, 2] = _state[(int)face, 2, 2];
            newState[(int)face, 0, 1] = _state[(int)face, 1, 2];
        }

        private void RotateRightFaceAntiClockwise()
        {
            var newState = (char[,,])_state.Clone();
            ShiftColumnFromOneFaceToColumnOfAnotherFace(Face.Front, 2, Face.Up, 2, newState);
            ShiftColumnFromOneFaceToColumnOfAnotherFace(Face.Up, 2, Face.Back, 0, newState);
            ShiftFlippedColumnFromOneFaceToColumnOfAnotherFace(Face.Back, 0, Face.Down, 2, newState);
            ShiftColumnFromOneFaceToColumnOfAnotherFace(Face.Down, 2, Face.Front, 2, newState);
            RotateFaceAntiClockwise(Face.Right, newState);
            _state = newState;
        }

        private void ShiftColumnFromOneFaceToColumnOfAnotherFace(Face faceTo, int columnTo, Face faceFrom, int columnFrom, char[,,] newState)
        {
            newState[(int)faceTo, columnTo, 0] = _state[(int)faceFrom, columnFrom, 0];
            newState[(int)faceTo, columnTo, 1] = _state[(int)faceFrom, columnFrom, 1];
            newState[(int)faceTo, columnTo, 2] = _state[(int)faceFrom, columnFrom, 2];
        }

        private void ShiftFlippedColumnFromOneFaceToColumnOfAnotherFace(Face faceTo, int columnTo, Face faceFrom, int columnFrom, char[,,] newState)
        {
            newState[(int)faceTo, columnTo, 0] = _state[(int)faceFrom, columnFrom, 2];
            newState[(int)faceTo, columnTo, 1] = _state[(int)faceFrom, columnFrom, 1];
            newState[(int)faceTo, columnTo, 2] = _state[(int)faceFrom, columnFrom, 0];
        }

        private void RotateFaceAntiClockwise(Face face, char[,,] newState)
        {
            newState[(int)face, 0, 2] = _state[(int)face, 0, 0];
            newState[(int)face, 0, 1] = _state[(int)face, 1, 0];
            newState[(int)face, 0, 0] = _state[(int)face, 2, 0];
            newState[(int)face, 1, 0] = _state[(int)face, 2, 1];
            newState[(int)face, 2, 0] = _state[(int)face, 2, 2];
            newState[(int)face, 2, 1] = _state[(int)face, 1, 2];
            newState[(int)face, 2, 2] = _state[(int)face, 0, 2];
            newState[(int)face, 1, 2] = _state[(int)face, 0, 1];
        }

        private void RotateUpFaceClockwise()
        {
            var newState = (char[,,])_state.Clone();
            ShiftTopRowFromOneFaceToAnother(Face.Left, Face.Front, newState);
            ShiftTopRowFromOneFaceToAnother(Face.Front, Face.Right, newState);
            ShiftTopRowFromOneFaceToAnother(Face.Right, Face.Back, newState);
            ShiftTopRowFromOneFaceToAnother(Face.Back, Face.Left, newState);
            RotateFaceClockwise(Face.Up, newState);
            _state = newState;
        }

        private void ShiftTopRowFromOneFaceToAnother(Face faceTo, Face faceFrom, char[,,] newState)
        {
            ShiftRowFromOneFaceToAnother(faceTo, faceFrom, 0, newState);
        }

        private void ShiftRowFromOneFaceToAnother(Face faceTo, Face faceFrom, int row, char[,,] newState)
        {
            newState[(int)faceTo, 0, row] = _state[(int)faceFrom, 0, row];
            newState[(int)faceTo, 1, row] = _state[(int)faceFrom, 1, row];
            newState[(int)faceTo, 2, row] = _state[(int)faceFrom, 2, row];
        }

        private void RotateBackFaceAntiClockwise()
        {
            var newState = (char[,,])_state.Clone();
            ShiftFlippedColumnFromOneFaceToRowOfAnotherFace(Face.Down, 2, Face.Right, 2, newState);
            ShiftRowFromOneFaceToColumnOfAnotherFace(Face.Left, 0, Face.Down, 2, newState);
            ShiftRowFromOneFaceToColumnOfAnotherFace(Face.Right, 2, Face.Up, 0, newState);
            ShiftFlippedColumnFromOneFaceToRowOfAnotherFace(Face.Up, 0, Face.Left, 0, newState);
            RotateFaceAntiClockwise(Face.Back, newState);
            _state = newState;
        }

        private void ShiftFlippedColumnFromOneFaceToRowOfAnotherFace(Face faceTo, int rowTo, Face faceFrom, int columnFrom, char[,,] newState)
        {
            newState[(int)faceTo, 0, rowTo] = _state[(int)faceFrom, columnFrom, 2];
            newState[(int)faceTo, 1, rowTo] = _state[(int)faceFrom, columnFrom, 1];
            newState[(int)faceTo, 2, rowTo] = _state[(int)faceFrom, columnFrom, 0];
        }

        private void RotateLeftFaceClockwise()
        {
            var newState = (char[,,])_state.Clone();
            ShiftColumnFromOneFaceToColumnOfAnotherFace(Face.Front, 0, Face.Up, 0, newState);
            ShiftFlippedColumnFromOneFaceToColumnOfAnotherFace(Face.Up, 0, Face.Back, 2, newState);
            ShiftFlippedColumnFromOneFaceToColumnOfAnotherFace(Face.Back, 2, Face.Down, 0, newState);
            ShiftColumnFromOneFaceToColumnOfAnotherFace(Face.Down, 0, Face.Front, 0, newState);
            RotateFaceClockwise(Face.Left, newState);
            _state = newState;
        }

        private void RotateDownFaceAnticlockwise()
        {
            var newState = (char[,,])_state.Clone();
            ShiftBottomRowFromOneFaceToAnother(Face.Front, Face.Right, newState);
            ShiftBottomRowFromOneFaceToAnother(Face.Left, Face.Front, newState);
            ShiftBottomRowFromOneFaceToAnother(Face.Right, Face.Back, newState);
            ShiftBottomRowFromOneFaceToAnother(Face.Back, Face.Left, newState);
            RotateFaceAntiClockwise(Face.Down, newState);
            _state = newState;
        }

        private void ShiftBottomRowFromOneFaceToAnother(Face faceTo, Face faceFrom, char[,,] newState)
        {
            ShiftRowFromOneFaceToAnother(faceTo, faceFrom, 2, newState);
        }

        public string PrintState()
        {
            return new StatePrinter(this).PrintState();
        }
    }
}
