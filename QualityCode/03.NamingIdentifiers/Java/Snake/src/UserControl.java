import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

/**
 * Represents user control of the snake object by arrow keys.
 * Control is based on the changing snake velocity in different
 * directions.
 */
public class UserControl implements KeyListener {

    /**
     * Initialize an instance of the UserControl class.
     *
     * @param game Instance of the Game class.
     */
    public UserControl(Engine game) {
        game.addKeyListener(this);
    }

    /**
     * Controls movement of the Snake instance with arrow keys
     * or ESC key for exit game.
     *
     * @param e Additional data associate with pressed key.
     */
    public void keyPressed(KeyEvent e) {
        final int VELOCITY = 20;
        int keyCode = e.getKeyCode();

        if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
            if (Engine.snake.getVelocityY() != VELOCITY) {
                Engine.snake.setVelocityX(0);
                Engine.snake.setVelocityY(-VELOCITY);
            }
        }

        if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
            if (Engine.snake.getVelocityY() != -VELOCITY) {
                Engine.snake.setVelocityX(0);
                Engine.snake.setVelocityY(VELOCITY);
            }
        }

        if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
            if (Engine.snake.getVelocityX() != -VELOCITY) {
                Engine.snake.setVelocityX(VELOCITY);
                Engine.snake.setVelocityY(0);
            }
        }

        if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
            if (Engine.snake.getVelocityX() != VELOCITY) {
                Engine.snake.setVelocityX(-VELOCITY);
                Engine.snake.setVelocityY(0);
            }
        }

        if (keyCode == KeyEvent.VK_ESCAPE) {
            System.exit(0);
        }
    }

    /**
     * Not used.
     *
     * @param e KeyEvent data.
     */
    public void keyReleased(KeyEvent e) {
    }

    /**
     * Not used.
     *
     * @param e KeyEvent data.
     */
    public void keyTyped(KeyEvent e) {
    }
}
