<?php
$textInput = preg_split('/\n/', $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);
$artist = $_GET['artist'];
$sort = $_GET['property'];
$order = $_GET['order'];

$songs = array();
foreach ($textInput as $line) {
    $splitted = explode('|', $line);
    $artists = explode(', ', trim($splitted[2]));
    sort($artists);
    $songs[trim($splitted[0])] = ["genre" => trim($splitted[1]), "artists" => $artists,
        "downloads" => (int)$splitted[3], "rate" => (float)$splitted[4], "name" => trim($splitted[0])];
}

$filtered = array_filter($songs, function ($item) use ($artist) {
    $singers = $item['artists'];
    if (in_array($artist, $singers)) {
        return true;
    }
    return false;
});
if ($sort == "name") {
    if ($order == 'ascending') {
        ksort($filtered);
    } else {
        krsort($filtered);
    }
} else {
    uasort($filtered, function ($a, $b) use ($sort, $order) {
        switch ($sort) {
            case "genre":
                if ($a['genre'] !== $b['genre']) {
                    if ($order == "ascending") {
                        return $a['genre'] < $b['genre'] ? -1 : 1;
                    } else {
                        return $a['genre'] < $b['genre'] ? 1 : -1;
                    }
                } else {
                    return $a['name'] < $b['name'] ? -1 : 1;
                }
                break;
            case "downloads":
                if ($a['downloads'] !== $b['downloads']) {
                    if ($order == "ascending") {
                        return $a['downloads'] < $b['downloads'] ? -1 : 1;
                    } else {
                        return $a['downloads'] < $b['downloads'] ? 1 : -1;
                    }
                } else {
                    return $a['name'] < $b['name'] ? -1 : 1;
                }
                break;
            case "rating":
                if ($a['rate'] !== $b['rate']) {
                    if ($order == "ascending") {
                        return $a['rate'] < $b['rate'] ? -1 : 1;
                    } else {
                        return $a['rate'] < $b['rate'] ? 1 : -1;
                    }
                } else {
                    return $a['name'] < $b['name'] ? -1 : 1;
                }
                break;
        }
    });
}

$result = "<table>\n<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";
foreach ($filtered as $key => $song) {
    $name = htmlspecialchars($key);
    $genre = htmlspecialchars($song['genre']);
    $singers = htmlspecialchars(implode(', ', $song['artists']));
    $downloads = htmlspecialchars($song['downloads']);
    $rating = htmlspecialchars($song['rate']);
    $result .= "<tr><td>{$name}</td><td>{$genre}</td><td>{$singers}</td><td>{$downloads}</td><td>{$rating}</td></tr>\n";
}

echo "$result</table>";