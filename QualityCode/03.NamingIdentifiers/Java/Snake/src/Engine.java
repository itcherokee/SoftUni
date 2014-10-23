import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * Represents main game Engine object, where all the game run logic
 * is established, including objects drawing on the Canvas.
 */
@SuppressWarnings("serial")
public class Engine extends Canvas implements Runnable {
    public static Snake snake;
    public static Target target;
    static int score;
    private Graphics globalContext;
    private Thread runThread;
    public static final int WIDTH = 600;
    public static final int HEIGHT = 600;
    private final Dimension GAME_BOARD_SIZE = new Dimension(WIDTH, HEIGHT);
    static boolean isGameRunning = false;

    /**
     * Prepares the graphical canvas for drawing of the game objects.
     * @param context Instance of Graphical context - canvas
     *                where to draw game objects.
     */
    public void paint(Graphics context) {
        this.setPreferredSize(GAME_BOARD_SIZE);
        globalContext = context.create();
        score = 0;

        if (runThread == null) {
            runThread = new Thread(this);
            runThread.start();
            isGameRunning = true;
        }
    }

    /**
     * Executes main game loop until end of the game.
     */
    public void run() {
        while (isGameRunning) {
            snake.move();
            render(globalContext);
            try {
                Thread.sleep(100);
            } catch (Exception e) {
            }
        }
    }

    /**
     * Initialize an instance of the game Engine class.
     */
    public Engine() {
        snake = new Snake();
        target = new Target(snake);
    }

    /**
     * Renders on the Canvas (context) all game objects.
     * @param context instance of Graphical context - canvas
     *                where to draw game objects.
     */
    public void render(Graphics context) {
        context.clearRect(0, 0, WIDTH, HEIGHT + 25);
        context.drawRect(0, 0, WIDTH, HEIGHT);
        snake.drawSnake(context);
        target.drawTarget(context);
        context.drawString("score = " + score, 10, HEIGHT + 25);
    }
}
