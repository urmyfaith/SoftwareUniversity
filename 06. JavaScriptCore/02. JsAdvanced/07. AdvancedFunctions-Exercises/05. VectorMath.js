let solution = (() => {
    function add(v1, v2) {
        return [v1[0] + v2[0], v1[1] + v2[1]];
    }

    function multiply(v1, m) {
        return [v1[0] * m, v1[1] * m];
    }

    function length(v) {
        return Math.sqrt(v[0] * v[0] + v[1] * v[1]);
    }

    function dot(v1, v2) {
        return v1[0] * v1[1] + v2[0] * v2[1];
    }

    function cross(v1, v2) {
        return v1[0] * v2[1] - v1[1] * v2[0];
    }

    return { add, multiply, length, dot, cross };
})();

console.log(solution.add([1, 1], [1, 0]));
console.log(solution.multiply([3.5, -2], 2));
console.log(solution.length([3, -4]));
console.log(solution.dot([1, 0], [0, -1]));
console.log(solution.cross([3, 7], [1, 0]));