import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/**
 * Represents a snake object consists of multiple Points objects.
 */
public class Snake {
    LinkedList<Point> snakeBody = new LinkedList<Point>();
    private Color snakeColor;
    private int velocityX;
    private int velocityY;

    /**
     * Initialize an instance of the class Snake that
     * consists of multiple instances of the Point class.
     */
    public Snake() {
        snakeColor = Color.GREEN;
        snakeBody.add(new Point(300, 100));
        snakeBody.add(new Point(280, 100));
        snakeBody.add(new Point(260, 100));
        snakeBody.add(new Point(240, 100));
        snakeBody.add(new Point(220, 100));
        snakeBody.add(new Point(200, 100));
        snakeBody.add(new Point(180, 100));
        snakeBody.add(new Point(160, 100));
        snakeBody.add(new Point(140, 100));
        snakeBody.add(new Point(120, 100));
        velocityX = 20;
        velocityY = 0;
    }

    /**
     * Draws the snake on the Canvas (context).
     * @param context Graphics type instance representing canvas
     *                used for drawing.
     */
    public void drawSnake(Graphics context) {
        for (Point point : this.snakeBody) {
            point.drawPoint(context, snakeColor);
        }
    }

    /**
     * Executes main logic for manipulation of current instance of
     * Snake class. Executes movement of the snake instance on
     * the canvas.
     */
    public void move() {
        Point currentSnakePosition =
                new Point(
                        (snakeBody.get(0).getX() + velocityX),
                        (snakeBody.get(0).getY() + velocityY));

        if (currentSnakePosition.getX() > Engine.WIDTH - 20) {
            Engine.isGameRunning = false;
        } else if (currentSnakePosition.getX() < 0) {
            Engine.isGameRunning = false;
        } else if (currentSnakePosition.getY() < 0) {
            Engine.isGameRunning = false;
        } else if (currentSnakePosition.getY() > Engine.HEIGHT - 20) {
            Engine.isGameRunning = false;
        } else if (Engine.target.getTarget().equals(currentSnakePosition)) {
            snakeBody.add(Engine.target.getTarget());
            Engine.target = new Target(this);
            Engine.score += 50;
        } else if (snakeBody.contains(currentSnakePosition)) {
            Engine.isGameRunning = false;
            System.out.println("You ate yourself");
        }

        for (int i = snakeBody.size() - 1; i > 0; i--) {
            snakeBody.set(i, new Point(snakeBody.get(i - 1)));
        }

        snakeBody.set(0, currentSnakePosition);
    }

    /**
     * Gets current Snake instance velocity by ordinate.
     * @return Velocity value by X axis.
     */
    public int getVelocityX() {
        return velocityX;
    }

    /**
     * Sets Snake instance velocity by abscissa.
     * @param velocityX X velocity
     */
    public void setVelocityX(int velocityX) {
        this.velocityX = velocityX;
    }

    /**
     * Gets current Snake instance velocity by abscissa.
     * @return Velocity value by Y axis.
     */
    public int getVelocityY() {
        return velocityY;
    }

    /**
     * Sets Snake instance velocity by ordinate.
     * @param velocityY Y velocity
     */
    public void setVelocityY(int velocityY) {
        this.velocityY = velocityY;
    }
}
