///<reference path="JsBST.js"/>

test("test BST", function() {
    var bst = new BST();
    bst.buildBst(5);
    bst.buildBst(2);
    bst.buildBst(4);
    bst.buildBst(3);
    bst.buildBst(9);
    bst.buildBst(6);
    bst.buildBst(7);
    bst.buildBst(1);
    bst.buildBst(8);

    bst.inOrder(bst.root);
    equal(1, 1, "dummy result");
});

test("reverse string", function () {
    var source = "this is test";
    var len = source.length;
    var i = 0, j = len - 1;
    var result = [];
    while (i < j) {
        result[i] = source[j];
        result[j] = source[i];
        i++;
        j--;
    }

    result = result.join('');
    equal(result, "tset si siht", "Reverse string");
});
