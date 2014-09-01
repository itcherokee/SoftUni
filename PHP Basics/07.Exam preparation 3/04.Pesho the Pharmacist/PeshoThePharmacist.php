<?php
date_default_timezone_set('Europe/Sofia');

$inputInvoices = $_GET['invoices'];
$inputDate = $_GET['today'];

$endDate = strtotime(str_replace('/', '-', $inputDate));
$startDate = strtotime('-5 years', $endDate);

$journal = array();
foreach ($inputInvoices as $invoice) {
    $invoiceSplit = preg_split('/\s*\|\s*/', $invoice, -1, PREG_SPLIT_NO_EMPTY);
    $date = strtotime(str_replace('/', '-', $invoiceSplit[0]));
    $dateBack = date('d-m-Y', $date);
    $company = $invoiceSplit[1];
    $drug = $invoiceSplit[2];
    $amount = (double)str_replace('lv', '', $invoiceSplit[3]);
    if (isset($journal[$date])) {
        // date exist -> add company -> add drug -> add amount
        if (isset($journal[$date][$company])) {
            if (in_array($drug, $journal[$date][$company][0])) {
                $journal[$date][$company][1] += $amount;
            } else {
                $journal[$date][$company][0][] = $drug;
                $journal[$date][$company][1] += $amount;
            }
        } else {
            $journal[$date][$company] = array(array($drug), $amount);
        }
    } else if ($startDate <= $date) {
        // new date
        $new_company = array(array($drug), $amount);
        $journal[$date] = array($company => $new_company);

    }
}

foreach ($journal as $date => &$values) {
    ksort($values);
    foreach ($values as &$items) {
        sort($items[0]);

    }
}

ksort($journal);
echo showResult($journal);

function showResult($array)
{
    $result = "<ul>";
    foreach ($array as $date => $company) {
        $result .= "<li><p>" . date("d/m/Y", $date) . "</p>";
        foreach ($company as $name => $values) {
            $result .= "<ul><li><p>$name</p><ul>";
            $result .= "<li><p>" . implode(',', $values[0]) . "-{$values[1]}lv</p></li></ul></li></ul>";
        }
        $result .= "</li>";
    }
    return "{$result}</ul>";
}

?>
