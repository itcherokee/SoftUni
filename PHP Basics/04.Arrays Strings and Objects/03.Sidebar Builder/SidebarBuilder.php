<?php
// Task 3:  Write a PHP program SidebarBuilder.php that takes data from several input fields
//          and builds 3 sidebars. The input fields are categories, tags and months. The first
//          sidebar should contain a list of the categories, the second sidebar – a list of
//          the tags and the third should contain the months. The entries in the input strings
//          will be separated by a comma and space ", ". Styling the page is optional.
//          Semantic HTML is required.

header("Content-Type: text/html; charset=utf-8");

function parseInput($data)
{
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlentities($data);
    return $data;
}

function buildSidebarMenu($title, $input)
{
    $title = ucwords($title);
    $result = "<aside><header><h2>{$title}</h2></header><section><ul>";
    $items = preg_split('/\P{L}+/u', $input, -1, PREG_SPLIT_NO_EMPTY);
    for ($i = 0; $i < count($items); $i++) {
        $result .= "<li><a href='/'>{$items[$i]}</a></li>";
    }

    return "{$result}</ul></section></aside>";
}

define ("CATEGORIES", "categories");
define ("TAGS", "tags");
define ("MONTHS", "months");

if (!empty($_GET[CATEGORIES]) && !empty($_GET[TAGS]) && !empty($_GET[MONTHS])) {
    $firstSidebar = buildSidebarMenu(CATEGORIES, parseInput($_GET[CATEGORIES]));
    $secondSidebar = buildSidebarMenu(TAGS, parseInput($_GET[TAGS]));
    $thirdSidebar = buildSidebarMenu(MONTHS, parseInput($_GET[MONTHS]));
    $result = $firstSidebar . $secondSidebar . $thirdSidebar;
} else {
    $result = '';
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Word Mapping</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<main>
    <form action="" method="get">
        <div>
            <label for="categories">Categories: </label>
            <input type="text" name="categories" id="categories"/>
        </div>
        <div>
            <label for="tags">Tags: </label>
            <input type="text" name="tags" id="tags"/>
        </div>
        <div>
            <label for="months">Months: </label>
            <input type="text" name="months" id="months"/>
        </div>
        <input type="submit" value="Generate"/>
    </form>
    <?= $result; ?>
</main>
<script>
    document.getElementById('categories').value = "<?= $_GET[CATEGORIES]; ?>";
    document.getElementById('tags').value = "<?= $_GET[TAGS]; ?>";
    document.getElementById('months').value = "<?= $_GET[MONTHS]; ?>";
</script>
</body>
</html>