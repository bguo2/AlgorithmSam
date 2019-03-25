//Javascript BST
"use strict";

//or function TreeNode(value)
var TreeNode = function(value) {
    this.data = value;
    this.left = null;
    this.right = null;
};

//or function BST()
var BST = function() {
    this.root = null;
};

BST.prototype = {
    buildBst: function(value) {
        if (this.root == null) {
            this.root = this.createNode(value);
            return;
        }
        this.insert(this.root, value);
    },
    
    insert: function (treeNode, value) {              
        if (treeNode == null || value == null) {
            return;
        }
        
        if (value < treeNode.data) {
            if (treeNode.left == null)
                treeNode.left = this.createNode(value);
            else {
                this.insert(treeNode.left, value);
            }
        } else {
            if (treeNode.right == null)
                treeNode.right = this.createNode(value);
            else {
                this.insert(treeNode.right, value);
            }
        }
    },
    
    createNode: function(value) {
        return new TreeNode(value);
    },

    result: [],
    inOrder: function (treeNode) {
        if (treeNode == null)
            return;
        this.inOrder(treeNode.left);
        this.result.push(treeNode.data);
        this.inOrder(treeNode.right);
    }
}