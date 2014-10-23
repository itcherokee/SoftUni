import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/**
 * Represents the Target object (apple) in the game logic.
 */
public class Target {
    public static Random coordinatesGenerator;
    private Point target;
    private Color targetColor;

    /**
     * Initialize an instance of the Target class.
     * @param snake Snake class instance used to check for collision
     *              during the generating the Target object.
     */
    public Target(Snake snake) {
        target = generateTargetPosition(snake);
        targetColor = Color.RED;
    }

    /**
     * Generates the coordinates of the Target object by suppressing
     * eventual collision with Snake object.
     * @param snake Snake class instance.
     * @return Instance of Point class with valid coordinates.
     */
    private Point generateTargetPosition(Snake snake) {
        coordinatesGenerator = new Random();
        int x = coordinatesGenerator.nextInt(30) * 20;
        int y = coordinatesGenerator.nextInt(30) * 20;
        for (Point snakePoint : snake.snakeBody) {
            if (x == snakePoint.getX() || y == snakePoint.getY()) {
                return generateTargetPosition(snake);
            }
        }

        return new Point(x, y);
    }

    /**
     * Draws Target instance on the Canvas.
     * @param context Graphics type instance representing
     *                canvas used for drawing.
     */
    public void drawTarget(Graphics context) {
        target.drawPoint(context, targetColor);
    }

    /**
     * Gets Target instance position.
     * @return Instance of class Point representing
     * coordinates of the Target instance.
     */
    public Point getTarget() {
        return target;
    }
}
