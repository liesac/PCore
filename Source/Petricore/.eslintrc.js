module.exports = {
    "extends": "eslint:recommended",
    "installedESLint": true,
    "parserOptions": {
        "ecmaVersion": 6,
        "sourceType": "script"
    },
    "env": {
        "browser": true,
        "node": true
    },
    "rules": {
        "quotes": ["error", "single"],
        "max-len": ["error", 400],
        "indent": ["error", 4],
        "semi": ["error", "always"]
    },
    "globals": {
        "angular": true,
        "$": true,
        "$location": true
    }
};