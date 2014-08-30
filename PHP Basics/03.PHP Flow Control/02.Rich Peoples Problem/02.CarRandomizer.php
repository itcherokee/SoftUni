<?php
// Task 2:  You are a very rich billionaire with an unhidden passion for cars. You like certain car
//          manufacturers but you don’t really care about anything else, and that’s why you need your
//          own randomizing algorithm that helps you decide how many and what color cars you should buy.
//          Write a PHP script CarRandomizer.php that receives a string of cars from an input HTML form,
//          separated by a comma and space (“, “). It then prints each car, a random color and a random
//          quantity in a table like the one shown below. Use colors by your choice. Use as quantity
//          a random number in range [1...5]. Styling the page is optional.

header("Content-Type: text/html; charset=utf8");
$color = ['red', 'blue', 'yellow', 'cyan', 'brown', 'black', 'magenta', 'green', 'pink'];
?>

<!DOCTYPE html>
<html>
<head>
    <title>Rich People's Problem</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<form action="" method="post">
    <label for="cars">Enter cars</label>
    <input type="text" id="cars" name="cars"/>
    <input type="submit" value="Show result"/>
</form>
<script>
    document.getElementById('cars').value = "<?php  echo $_POST['cars']; ?>";
</script>
<?php
if (!empty($_POST['cars'])) :
    $cars = preg_split('/[\s,]+/', htmlentities($_POST['cars']));
    ?>
    <table>
        <thead>
        <tr>
            <th>Car</th>
            <th>Color</th>
            <th>Count</th>
        </tr>
        </thead>
        <tbody>
        <?php
        for ($i = 0; $i < count($cars); $i += 1):
            ?>
            <tr>
                <td><?= $cars[$i] ?></td>
                <td><?= $color[rand(0, count($color) - 1)]; ?></td>
                <td><?= rand(1, 5); ?></td>
            </tr>
        <?php endfor; ?>
        </tbody>
    </table>
<?php endif; ?>
</body>
</html>