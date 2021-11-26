using System;

public enum Direction
{
    North  = 0b00000010, // 2
    East   = 0b00001000, // 8
    South  = 0b00100000, // 32
    West   = 0b10000000  // 128
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    
    // Bitwise Rotation.
    private static byte RotateRight(byte value) => (byte)((value << 2) | (value >> 6));
    private static byte RotateLeft(byte value) => (byte)((value >> 2) | (value << 6));

    public void Move(string instructions)
    {
        void ShiftInstruction() => instructions = instructions[1..];
        
        while (instructions.Length > 0)
        {
            if (instructions[0] == 'R') Direction = (Direction)RotateRight((byte)Direction);
            if (instructions[0] == 'L') Direction = (Direction)RotateLeft((byte)Direction);
            if (instructions[0] == 'A')
            {
                switch (Direction)
                {
                    case Direction.North:
                        Y++;
                        break;
                    case Direction.South:
                        Y--;
                        break;
                    case Direction.West:
                        X--;
                        break;
                    case Direction.East:
                        X++;
                        break;
                    default:
                        throw new 
                            ArgumentOutOfRangeException($"Current state {Direction} is invalid.");
                }
            }
            ShiftInstruction();
        }
    }
}