import java.awt.Color;
import java.awt.Graphics;

/**
 * Represent a point (cube) on the game field with dimensions
 * set by WIDTH and HEIGHT constants.
 */
public class Point {
    private final int WIDTH = 20;
    private final int HEIGHT = 20;
    private int x;
    private int y;

    /**
     * Initialize an instance of the Point class by using
     * coordinates of already existing Point object.
     * @param point Already instantiated Point object
     *              with coordinates 'x' and 'y'
     */
    public Point(Point point) {
        this(point.x, point.y);
    }

    /**
     * Initialize an instance of the Point class.
     * @param x X coordinate
     * @param y Y coordinate
     */
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }

    /**
     * Gets X coordinate value.
     * @return X coordinate value as integer.
     */
    public int getX() {
        return x;
    }

    /**
     * Gets Y coordinate value.
     * @return Y coordinate value as integer.
     */
    public int getY() {
        return y;
    }

    /**
     * Draws on the Canvas (context) the point represented by current
     * instance of Point class.
     * @param context Graphics type representing canvas used for drawing.
     * @param pointColor Color to be used for drawing the Point.
     */
    public void drawPoint(Graphics context, Color pointColor) {
        // draws bigger square that will represent border (black)
        context.setColor(Color.BLACK);
        context.fillRect(x, y, WIDTH, HEIGHT);
        // draws internal fill (green) of the point
        context.setColor(pointColor);
        context.fillRect(x + 1, y + 1, WIDTH - 2, HEIGHT - 2);
    }

    /**
     * String representation of the current state of that instance
     * of class Point.
     * @return String representation of state.
     */
    public String toString() {
        return "[x=" + this.x + ",y=" + this.y + "]";
    }

    /**
     * Compares to instances of Point class for equality by using
     * the internal state: 'x' and 'y' coordinates.
     * @param object Other object to be compared with that instance of
     *               Point class.
     * @return True if both instances are equal (equal coordinates).
     */
    public boolean equals(Object object) {
        if (object instanceof Point) {
            Point point = (Point) object;
            return (this.x == point.x) && (this.y == point.y);
        }

        return false;
    }
}
