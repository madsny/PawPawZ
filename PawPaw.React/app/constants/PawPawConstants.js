'use strict';
var keyMirror = require('react/lib/keyMirror');

var constants = keyMirror({
	GROUPS_FETCH: null,
	GROUPS_FETCH_SUCCESS: null,
	GROUPS_FETCH_FAIL: null,
	GROUP_POST: null,
	GROUP_POST_SUCCESS: null,
	GROUP_POST_FAIL: null
});

module.exports = constants;