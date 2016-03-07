(function () {
    function e(e) {
        function t(t, n, i, r, o, a) {
            for (; o >= 0 && a > o; o += e) {
                var s = r ? r[o] : o;
                i = n(i, t[s], s, t)
            }
            return i
        }
        return function (n, i, r, o) {
            i = y(i, o, 4);
            var a = !T(n) && v.keys(n),
			s = (a || n).length,
			u = e > 0 ? 0 : s - 1;
            return arguments.length < 3 && (r = n[a ? a[u] : u], u += e),
			t(n, i, r, a, u, s)
        }
    }
    function t(e) {
        return function (t, n, i) {
            n = x(n, i);
            for (var r = null != t && t.length,
			o = e > 0 ? 0 : r - 1; o >= 0 && r > o; o += e) if (n(t[o], o, t)) return o;
            return -1
        }
    }
    function n(e, t) {
        var n = E.length,
		i = e.constructor,
		r = v.isFunction(i) && i.prototype || a,
		o = "constructor";
        for (v.has(e, o) && !v.contains(t, o) && t.push(o) ; n--;) o = E[n],
		o in e && e[o] !== r[o] && !v.contains(t, o) && t.push(o)
    }
    var i = this,
	r = i._,
	o = Array.prototype,
	a = Object.prototype,
	s = Function.prototype,
	u = o.push,
	c = o.slice,
	l = a.toString,
	f = a.hasOwnProperty,
	d = Array.isArray,
	p = Object.keys,
	h = s.bind,
	g = Object.create,
	m = function () { },
	v = function (e) {
	    return e instanceof v ? e : this instanceof v ? void (this._wrapped = e) : new v(e)
	};
    "undefined" != typeof exports ? ("undefined" != typeof module && module.exports && (exports = module.exports = v), exports._ = v) : i._ = v,
	v.VERSION = "1.8.2";
    var y = function (e, t, n) {
        if (void 0 === t) return e;
        switch (null == n ? 3 : n) {
            case 1:
                return function (n) {
                    return e.call(t, n)
                };
            case 2:
                return function (n, i) {
                    return e.call(t, n, i)
                };
            case 3:
                return function (n, i, r) {
                    return e.call(t, n, i, r)
                };
            case 4:
                return function (n, i, r, o) {
                    return e.call(t, n, i, r, o)
                }
        }
        return function () {
            return e.apply(t, arguments)
        }
    },
	x = function (e, t, n) {
	    return null == e ? v.identity : v.isFunction(e) ? y(e, t, n) : v.isObject(e) ? v.matcher(e) : v.property(e)
	};
    v.iteratee = function (e, t) {
        return x(e, t, 1 / 0)
    };
    var w = function (e, t) {
        return function (n) {
            var i = arguments.length;
            if (2 > i || null == n) return n;
            for (var r = 1; i > r; r++) for (var o = arguments[r], a = e(o), s = a.length, u = 0; s > u; u++) {
                var c = a[u];
                t && void 0 !== n[c] || (n[c] = o[c])
            }
            return n
        }
    },
	b = function (e) {
	    if (!v.isObject(e)) return {};
	    if (g) return g(e);
	    m.prototype = e;
	    var t = new m;
	    return m.prototype = null,
		t
	},
	k = Math.pow(2, 53) - 1,
	T = function (e) {
	    var t = e && e.length;
	    return "number" == typeof t && t >= 0 && k >= t
	};
    v.each = v.forEach = function (e, t, n) {
        t = y(t, n);
        var i, r;
        if (T(e)) for (i = 0, r = e.length; r > i; i++) t(e[i], i, e);
        else {
            var o = v.keys(e);
            for (i = 0, r = o.length; r > i; i++) t(e[o[i]], o[i], e)
        }
        return e
    },
	v.map = v.collect = function (e, t, n) {
	    t = x(t, n);
	    for (var i = !T(e) && v.keys(e), r = (i || e).length, o = Array(r), a = 0; r > a; a++) {
	        var s = i ? i[a] : a;
	        o[a] = t(e[s], s, e)
	    }
	    return o
	},
	v.reduce = v.foldl = v.inject = e(1),
	v.reduceRight = v.foldr = e(-1),
	v.find = v.detect = function (e, t, n) {
	    var i;
	    return i = T(e) ? v.findIndex(e, t, n) : v.findKey(e, t, n),
		void 0 !== i && -1 !== i ? e[i] : void 0
	},
	v.filter = v.select = function (e, t, n) {
	    var i = [];
	    return t = x(t, n),
		v.each(e,
		function (e, n, r) {
		    t(e, n, r) && i.push(e)
		}),
		i
	},
	v.reject = function (e, t, n) {
	    return v.filter(e, v.negate(x(t)), n)
	},
	v.every = v.all = function (e, t, n) {
	    t = x(t, n);
	    for (var i = !T(e) && v.keys(e), r = (i || e).length, o = 0; r > o; o++) {
	        var a = i ? i[o] : o;
	        if (!t(e[a], a, e)) return !1
	    }
	    return !0
	},
	v.some = v.any = function (e, t, n) {
	    t = x(t, n);
	    for (var i = !T(e) && v.keys(e), r = (i || e).length, o = 0; r > o; o++) {
	        var a = i ? i[o] : o;
	        if (t(e[a], a, e)) return !0
	    }
	    return !1
	},
	v.contains = v.includes = v.include = function (e, t, n) {
	    return T(e) || (e = v.values(e)),
		v.indexOf(e, t, "number" == typeof n && n) >= 0
	},
	v.invoke = function (e, t) {
	    var n = c.call(arguments, 2),
		i = v.isFunction(t);
	    return v.map(e,
		function (e) {
		    var r = i ? t : e[t];
		    return null == r ? r : r.apply(e, n)
		})
	},
	v.pluck = function (e, t) {
	    return v.map(e, v.property(t))
	},
	v.where = function (e, t) {
	    return v.filter(e, v.matcher(t))
	},
	v.findWhere = function (e, t) {
	    return v.find(e, v.matcher(t))
	},
	v.max = function (e, t, n) {
	    var i, r, o = -1 / 0,
		a = -1 / 0;
	    if (null == t && null != e) {
	        e = T(e) ? e : v.values(e);
	        for (var s = 0,
			u = e.length; u > s; s++) i = e[s],
			i > o && (o = i)
	    } else t = x(t, n),
		v.each(e,
		function (e, n, i) {
		    r = t(e, n, i),
			(r > a || r === -1 / 0 && o === -1 / 0) && (o = e, a = r)
		});
	    return o
	},
	v.min = function (e, t, n) {
	    var i, r, o = 1 / 0,
		a = 1 / 0;
	    if (null == t && null != e) {
	        e = T(e) ? e : v.values(e);
	        for (var s = 0,
			u = e.length; u > s; s++) i = e[s],
			o > i && (o = i)
	    } else t = x(t, n),
		v.each(e,
		function (e, n, i) {
		    r = t(e, n, i),
			(a > r || 1 / 0 === r && 1 / 0 === o) && (o = e, a = r)
		});
	    return o
	},
	v.shuffle = function (e) {
	    for (var t, n = T(e) ? e : v.values(e), i = n.length, r = Array(i), o = 0; i > o; o++) t = v.random(0, o),
		t !== o && (r[o] = r[t]),
		r[t] = n[o];
	    return r
	},
	v.sample = function (e, t, n) {
	    return null == t || n ? (T(e) || (e = v.values(e)), e[v.random(e.length - 1)]) : v.shuffle(e).slice(0, Math.max(0, t))
	},
	v.sortBy = function (e, t, n) {
	    return t = x(t, n),
		v.pluck(v.map(e,
		function (e, n, i) {
		    return {
		        value: e,
		        index: n,
		        criteria: t(e, n, i)
		    }
		}).sort(function (e, t) {
		    var n = e.criteria,
			i = t.criteria;
		    if (n !== i) {
		        if (n > i || void 0 === n) return 1;
		        if (i > n || void 0 === i) return -1
		    }
		    return e.index - t.index
		}), "value")
	};
    var S = function (e) {
        return function (t, n, i) {
            var r = {};
            return n = x(n, i),
			v.each(t,
			function (i, o) {
			    var a = n(i, o, t);
			    e(r, i, a)
			}),
			r
        }
    };
    v.groupBy = S(function (e, t, n) {
        v.has(e, n) ? e[n].push(t) : e[n] = [t]
    }),
	v.indexBy = S(function (e, t, n) {
	    e[n] = t
	}),
	v.countBy = S(function (e, t, n) {
	    v.has(e, n) ? e[n]++ : e[n] = 1
	}),
	v.toArray = function (e) {
	    return e ? v.isArray(e) ? c.call(e) : T(e) ? v.map(e, v.identity) : v.values(e) : []
	},
	v.size = function (e) {
	    return null == e ? 0 : T(e) ? e.length : v.keys(e).length
	},
	v.partition = function (e, t, n) {
	    t = x(t, n);
	    var i = [],
		r = [];
	    return v.each(e,
		function (e, n, o) {
		    (t(e, n, o) ? i : r).push(e)
		}),
		[i, r]
	},
	v.first = v.head = v.take = function (e, t, n) {
	    return null == e ? void 0 : null == t || n ? e[0] : v.initial(e, e.length - t)
	},
	v.initial = function (e, t, n) {
	    return c.call(e, 0, Math.max(0, e.length - (null == t || n ? 1 : t)))
	},
	v.last = function (e, t, n) {
	    return null == e ? void 0 : null == t || n ? e[e.length - 1] : v.rest(e, Math.max(0, e.length - t))
	},
	v.rest = v.tail = v.drop = function (e, t, n) {
	    return c.call(e, null == t || n ? 1 : t)
	},
	v.compact = function (e) {
	    return v.filter(e, v.identity)
	};
    var C = function (e, t, n, i) {
        for (var r = [], o = 0, a = i || 0, s = e && e.length; s > a; a++) {
            var u = e[a];
            if (T(u) && (v.isArray(u) || v.isArguments(u))) {
                t || (u = C(u, t, n));
                var c = 0,
				l = u.length;
                for (r.length += l; l > c;) r[o++] = u[c++]
            } else n || (r[o++] = u)
        }
        return r
    };
    v.flatten = function (e, t) {
        return C(e, t, !1)
    },
	v.without = function (e) {
	    return v.difference(e, c.call(arguments, 1))
	},
	v.uniq = v.unique = function (e, t, n, i) {
	    if (null == e) return [];
	    v.isBoolean(t) || (i = n, n = t, t = !1),
		null != n && (n = x(n, i));
	    for (var r = [], o = [], a = 0, s = e.length; s > a; a++) {
	        var u = e[a],
			c = n ? n(u, a, e) : u;
	        t ? (a && o === c || r.push(u), o = c) : n ? v.contains(o, c) || (o.push(c), r.push(u)) : v.contains(r, u) || r.push(u)
	    }
	    return r
	},
	v.union = function () {
	    return v.uniq(C(arguments, !0, !0))
	},
	v.intersection = function (e) {
	    if (null == e) return [];
	    for (var t = [], n = arguments.length, i = 0, r = e.length; r > i; i++) {
	        var o = e[i];
	        if (!v.contains(t, o)) {
	            for (var a = 1; n > a && v.contains(arguments[a], o) ; a++);
	            a === n && t.push(o)
	        }
	    }
	    return t
	},
	v.difference = function (e) {
	    var t = C(arguments, !0, !0, 1);
	    return v.filter(e,
		function (e) {
		    return !v.contains(t, e)
		})
	},
	v.zip = function () {
	    return v.unzip(arguments)
	},
	v.unzip = function (e) {
	    for (var t = e && v.max(e, "length").length || 0, n = Array(t), i = 0; t > i; i++) n[i] = v.pluck(e, i);
	    return n
	},
	v.object = function (e, t) {
	    for (var n = {},
		i = 0,
		r = e && e.length; r > i; i++) t ? n[e[i]] = t[i] : n[e[i][0]] = e[i][1];
	    return n
	},
	v.indexOf = function (e, t, n) {
	    var i = 0,
		r = e && e.length;
	    if ("number" == typeof n) i = 0 > n ? Math.max(0, r + n) : n;
	    else if (n && r) return i = v.sortedIndex(e, t),
		e[i] === t ? i : -1;
	    if (t !== t) return v.findIndex(c.call(e, i), v.isNaN);
	    for (; r > i; i++) if (e[i] === t) return i;
	    return -1
	},
	v.lastIndexOf = function (e, t, n) {
	    var i = e ? e.length : 0;
	    if ("number" == typeof n && (i = 0 > n ? i + n + 1 : Math.min(i, n + 1)), t !== t) return v.findLastIndex(c.call(e, 0, i), v.isNaN);
	    for (; --i >= 0;) if (e[i] === t) return i;
	    return -1
	},
	v.findIndex = t(1),
	v.findLastIndex = t(-1),
	v.sortedIndex = function (e, t, n, i) {
	    n = x(n, i, 1);
	    for (var r = n(t), o = 0, a = e.length; a > o;) {
	        var s = Math.floor((o + a) / 2);
	        n(e[s]) < r ? o = s + 1 : a = s
	    }
	    return o
	},
	v.range = function (e, t, n) {
	    arguments.length <= 1 && (t = e || 0, e = 0),
		n = n || 1;
	    for (var i = Math.max(Math.ceil((t - e) / n), 0), r = Array(i), o = 0; i > o; o++, e += n) r[o] = e;
	    return r
	};
    var _ = function (e, t, n, i, r) {
        if (!(i instanceof t)) return e.apply(n, r);
        var o = b(e.prototype),
		a = e.apply(o, r);
        return v.isObject(a) ? a : o
    };
    v.bind = function (e, t) {
        if (h && e.bind === h) return h.apply(e, c.call(arguments, 1));
        if (!v.isFunction(e)) throw new TypeError("Bind must be called on a function");
        var n = c.call(arguments, 2),
		i = function () {
		    return _(e, i, t, this, n.concat(c.call(arguments)))
		};
        return i
    },
	v.partial = function (e) {
	    var t = c.call(arguments, 1),
		n = function () {
		    for (var i = 0,
			r = t.length,
			o = Array(r), a = 0; r > a; a++) o[a] = t[a] === v ? arguments[i++] : t[a];
		    for (; i < arguments.length;) o.push(arguments[i++]);
		    return _(e, n, this, this, o)
		};
	    return n
	},
	v.bindAll = function (e) {
	    var t, n, i = arguments.length;
	    if (1 >= i) throw new Error("bindAll must be passed function names");
	    for (t = 1; i > t; t++) n = arguments[t],
		e[n] = v.bind(e[n], e);
	    return e
	},
	v.memoize = function (e, t) {
	    var n = function (i) {
	        var r = n.cache,
			o = "" + (t ? t.apply(this, arguments) : i);
	        return v.has(r, o) || (r[o] = e.apply(this, arguments)),
			r[o]
	    };
	    return n.cache = {},
		n
	},
	v.delay = function (e, t) {
	    var n = c.call(arguments, 2);
	    return setTimeout(function () {
	        return e.apply(null, n)
	    },
		t)
	},
	v.defer = v.partial(v.delay, v, 1),
	v.throttle = function (e, t, n) {
	    var i, r, o, a = null,
		s = 0;
	    n || (n = {});
	    var u = function () {
	        s = n.leading === !1 ? 0 : v.now(),
			a = null,
			o = e.apply(i, r),
			a || (i = r = null)
	    };
	    return function () {
	        var c = v.now();
	        s || n.leading !== !1 || (s = c);
	        var l = t - (c - s);
	        return i = this,
			r = arguments,
			0 >= l || l > t ? (a && (clearTimeout(a), a = null), s = c, o = e.apply(i, r), a || (i = r = null)) : a || n.trailing === !1 || (a = setTimeout(u, l)),
			o
	    }
	},
	v.debounce = function (e, t, n) {
	    var i, r, o, a, s, u = function () {
	        var c = v.now() - a;
	        t > c && c >= 0 ? i = setTimeout(u, t - c) : (i = null, n || (s = e.apply(o, r), i || (o = r = null)))
	    };
	    return function () {
	        o = this,
			r = arguments,
			a = v.now();
	        var c = n && !i;
	        return i || (i = setTimeout(u, t)),
			c && (s = e.apply(o, r), o = r = null),
			s
	    }
	},
	v.wrap = function (e, t) {
	    return v.partial(t, e)
	},
	v.negate = function (e) {
	    return function () {
	        return !e.apply(this, arguments)
	    }
	},
	v.compose = function () {
	    var e = arguments,
		t = e.length - 1;
	    return function () {
	        for (var n = t,
			i = e[t].apply(this, arguments) ; n--;) i = e[n].call(this, i);
	        return i
	    }
	},
	v.after = function (e, t) {
	    return function () {
	        return --e < 1 ? t.apply(this, arguments) : void 0
	    }
	},
	v.before = function (e, t) {
	    var n;
	    return function () {
	        return --e > 0 && (n = t.apply(this, arguments)),
			1 >= e && (t = null),
			n
	    }
	},
	v.once = v.partial(v.before, 2);
    var j = !{
        toString: null
    }.propertyIsEnumerable("toString"),
	E = ["valueOf", "isPrototypeOf", "toString", "propertyIsEnumerable", "hasOwnProperty", "toLocaleString"];
    v.keys = function (e) {
        if (!v.isObject(e)) return [];
        if (p) return p(e);
        var t = [];
        for (var i in e) v.has(e, i) && t.push(i);
        return j && n(e, t),
		t
    },
	v.allKeys = function (e) {
	    if (!v.isObject(e)) return [];
	    var t = [];
	    for (var i in e) t.push(i);
	    return j && n(e, t),
		t
	},
	v.values = function (e) {
	    for (var t = v.keys(e), n = t.length, i = Array(n), r = 0; n > r; r++) i[r] = e[t[r]];
	    return i
	},
	v.mapObject = function (e, t, n) {
	    t = x(t, n);
	    for (var i, r = v.keys(e), o = r.length, a = {},
		s = 0; o > s; s++) i = r[s],
		a[i] = t(e[i], i, e);
	    return a
	},
	v.pairs = function (e) {
	    for (var t = v.keys(e), n = t.length, i = Array(n), r = 0; n > r; r++) i[r] = [t[r], e[t[r]]];
	    return i
	},
	v.invert = function (e) {
	    for (var t = {},
		n = v.keys(e), i = 0, r = n.length; r > i; i++) t[e[n[i]]] = n[i];
	    return t
	},
	v.functions = v.methods = function (e) {
	    var t = [];
	    for (var n in e) v.isFunction(e[n]) && t.push(n);
	    return t.sort()
	},
	v.extend = w(v.allKeys),
	v.extendOwn = v.assign = w(v.keys),
	v.findKey = function (e, t, n) {
	    t = x(t, n);
	    for (var i, r = v.keys(e), o = 0, a = r.length; a > o; o++) if (i = r[o], t(e[i], i, e)) return i
	},
	v.pick = function (e, t, n) {
	    var i, r, o = {},
		a = e;
	    if (null == a) return o;
	    v.isFunction(t) ? (r = v.allKeys(a), i = y(t, n)) : (r = C(arguments, !1, !1, 1), i = function (e, t, n) {
	        return t in n
	    },
		a = Object(a));
	    for (var s = 0,
		u = r.length; u > s; s++) {
	        var c = r[s],
			l = a[c];
	        i(l, c, a) && (o[c] = l)
	    }
	    return o
	},
	v.omit = function (e, t, n) {
	    if (v.isFunction(t)) t = v.negate(t);
	    else {
	        var i = v.map(C(arguments, !1, !1, 1), String);
	        t = function (e, t) {
	            return !v.contains(i, t)
	        }
	    }
	    return v.pick(e, t, n)
	},
	v.defaults = w(v.allKeys, !0),
	v.clone = function (e) {
	    return v.isObject(e) ? v.isArray(e) ? e.slice() : v.extend({},
		e) : e
	},
	v.tap = function (e, t) {
	    return t(e),
		e
	},
	v.isMatch = function (e, t) {
	    var n = v.keys(t),
		i = n.length;
	    if (null == e) return !i;
	    for (var r = Object(e), o = 0; i > o; o++) {
	        var a = n[o];
	        if (t[a] !== r[a] || !(a in r)) return !1
	    }
	    return !0
	};
    var N = function (e, t, n, i) {
        if (e === t) return 0 !== e || 1 / e === 1 / t;
        if (null == e || null == t) return e === t;
        e instanceof v && (e = e._wrapped),
		t instanceof v && (t = t._wrapped);
        var r = l.call(e);
        if (r !== l.call(t)) return !1;
        switch (r) {
            case "[object RegExp]":
            case "[object String]":
                return "" + e == "" + t;
            case "[object Number]":
                return +e !== +e ? +t !== +t : 0 === +e ? 1 / +e === 1 / t : +e === +t;
            case "[object Date]":
            case "[object Boolean]":
                return +e === +t
        }
        var o = "[object Array]" === r;
        if (!o) {
            if ("object" != typeof e || "object" != typeof t) return !1;
            var a = e.constructor,
			s = t.constructor;
            if (a !== s && !(v.isFunction(a) && a instanceof a && v.isFunction(s) && s instanceof s) && "constructor" in e && "constructor" in t) return !1
        }
        n = n || [],
		i = i || [];
        for (var u = n.length; u--;) if (n[u] === e) return i[u] === t;
        if (n.push(e), i.push(t), o) {
            if (u = e.length, u !== t.length) return !1;
            for (; u--;) if (!N(e[u], t[u], n, i)) return !1
        } else {
            var c, f = v.keys(e);
            if (u = f.length, v.keys(t).length !== u) return !1;
            for (; u--;) if (c = f[u], !v.has(t, c) || !N(e[c], t[c], n, i)) return !1
        }
        return n.pop(),
		i.pop(),
		!0
    };
    v.isEqual = function (e, t) {
        return N(e, t)
    },
	v.isEmpty = function (e) {
	    return null == e ? !0 : T(e) && (v.isArray(e) || v.isString(e) || v.isArguments(e)) ? 0 === e.length : 0 === v.keys(e).length
	},
	v.isElement = function (e) {
	    return !(!e || 1 !== e.nodeType)
	},
	v.isArray = d ||
	function (e) {
	    return "[object Array]" === l.call(e)
	},
	v.isObject = function (e) {
	    var t = typeof e;
	    return "function" === t || "object" === t && !!e
	},
	v.each(["Arguments", "Function", "String", "Number", "Date", "RegExp", "Error"],
	function (e) {
	    v["is" + e] = function (t) {
	        return l.call(t) === "[object " + e + "]"
	    }
	}),
	v.isArguments(arguments) || (v.isArguments = function (e) {
	    return v.has(e, "callee")
	}),
	"function" != typeof / . / && "object" != typeof Int8Array && (v.isFunction = function (e) {
	    return "function" == typeof e || !1
	}),
	v.isFinite = function (e) {
	    return isFinite(e) && !isNaN(parseFloat(e))
	},
	v.isNaN = function (e) {
	    return v.isNumber(e) && e !== +e
	},
	v.isBoolean = function (e) {
	    return e === !0 || e === !1 || "[object Boolean]" === l.call(e)
	},
	v.isNull = function (e) {
	    return null === e
	},
	v.isUndefined = function (e) {
	    return void 0 === e
	},
	v.has = function (e, t) {
	    return null != e && f.call(e, t)
	},
	v.noConflict = function () {
	    return i._ = r,
		this
	},
	v.identity = function (e) {
	    return e
	},
	v.constant = function (e) {
	    return function () {
	        return e
	    }
	},
	v.noop = function () { },
	v.property = function (e) {
	    return function (t) {
	        return null == t ? void 0 : t[e]
	    }
	},
	v.propertyOf = function (e) {
	    return null == e ?
		function () { } : function (t) {
		    return e[t]
		}
	},
	v.matcher = v.matches = function (e) {
	    return e = v.extendOwn({},
		e),
		function (t) {
		    return v.isMatch(t, e)
		}
	},
	v.times = function (e, t, n) {
	    var i = Array(Math.max(0, e));
	    t = y(t, n, 1);
	    for (var r = 0; e > r; r++) i[r] = t(r);
	    return i
	},
	v.random = function (e, t) {
	    return null == t && (t = e, e = 0),
		e + Math.floor(Math.random() * (t - e + 1))
	},
	v.now = Date.now ||
	function () {
	    return (new Date).getTime()
	};
    var A = {
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': "&quot;",
        "'": "&#x27;",
        "`": "&#x60;"
    },
	O = v.invert(A),
	D = function (e) {
	    var t = function (t) {
	        return e[t]
	    },
		n = "(?:" + v.keys(e).join("|") + ")",
		i = RegExp(n),
		r = RegExp(n, "g");
	    return function (e) {
	        return e = null == e ? "" : "" + e,
			i.test(e) ? e.replace(r, t) : e
	    }
	};
    v.escape = D(A),
	v.unescape = D(O),
	v.result = function (e, t, n) {
	    var i = null == e ? void 0 : e[t];
	    return void 0 === i && (i = n),
		v.isFunction(i) ? i.call(e) : i
	};
    var I = 0;
    v.uniqueId = function (e) {
        var t = ++I + "";
        return e ? e + t : t
    },
	v.templateSettings = {
	    evaluate: /<%([\s\S]+?)%>/g,
	    interpolate: /<%=([\s\S]+?)%>/g,
	    escape: /<%-([\s\S]+?)%>/g
	};
    var q = /(.)^/,
	L = {
	    "'": "'",
	    "\\": "\\",
	    "\r": "r",
	    "\n": "n",
	    "\u2028": "u2028",
	    "\u2029": "u2029"
	},
	M = /\\|'|\r|\n|\u2028|\u2029/g,
	$ = function (e) {
	    return "\\" + L[e]
	};
    v.template = function (e, t, n) {
        !t && n && (t = n),
            t = v.defaults({},
            t, v.templateSettings);
        var i = RegExp([(t.escape || q).source, (t.interpolate || q).source, (t.evaluate || q).source].join("|") + "|$", "g"),
		r = 0,
		o = "__p+='";
        e.replace(i,
		function (t, n, i, a, s) {
		    return o += e.slice(r, s).replace(M, $),
			r = s + t.length,
			n ? o += "'+\n((__t=(" + n + "))==null?'':_.escape(__t))+\n'" : i ? o += "'+\n((__t=(" + i + "))==null?'':__t)+\n'" : a && (o += "';\n" + a + "\n__p+='"),
			t
		}),
		o += "';\n",
		t.variable || (o = "with(obj||{}){\n" + o + "}\n"),
		o = "var __t,__p='',__j=Array.prototype.join,print=function(){__p+=__j.call(arguments,'');};\n" + o + "return __p;\n";
        try {
            var a = new Function(t.variable || "obj", "_", o)
        } catch (s) {
            throw s.source = o,
			s
        }
        var u = function (e) {
            return a.call(this, e, v)
        },
		c = t.variable || "obj";
        return u.source = "function(" + c + "){\n" + o + "}",
		u
    },
	v.chain = function (e) {
	    var t = v(e);
	    return t._chain = !0,
		t
	};
    var P = function (e, t) {
        return e._chain ? v(t).chain() : t
    };
    v.mixin = function (e) {
        v.each(v.functions(e),
		function (t) {
		    var n = v[t] = e[t];
		    v.prototype[t] = function () {
		        var e = [this._wrapped];
		        return u.apply(e, arguments),
				P(this, n.apply(v, e))
		    }
		})
    },
	v.mixin(v),
	v.each(["pop", "push", "reverse", "shift", "sort", "splice", "unshift"],
	function (e) {
	    var t = o[e];
	    v.prototype[e] = function () {
	        var n = this._wrapped;
	        return t.apply(n, arguments),
			"shift" !== e && "splice" !== e || 0 !== n.length || delete n[0],
			P(this, n)
	    }
	}),
	v.each(["concat", "join", "slice"],
	function (e) {
	    var t = o[e];
	    v.prototype[e] = function () {
	        return P(this, t.apply(this._wrapped, arguments))
	    }
	}),
	v.prototype.value = function () {
	    return this._wrapped
	},
	v.prototype.valueOf = v.prototype.toJSON = v.prototype.value,
	v.prototype.toString = function () {
	    return "" + this._wrapped
	},
	"function" == typeof define && define.amd && define("underscore", [],
	function () {
	    return v
	})
}).call(this),
function () {
    !
        function (e, t) {
            "object" == typeof module && "object" == typeof module.exports ? module.exports = e.document ? t(e, !0) : function (e) {
                if (!e.document) throw new Error("jQuery requires a window with a document");
                return t(e)
            } : t(e)
        }("undefined" != typeof window ? window : this,
        function (e, t) {
            function n(e) {
                var t = "length" in e && e.length,
                n = Z.type(e);
                return "function" === n || Z.isWindow(e) ? !1 : 1 === e.nodeType && t ? !0 : "array" === n || 0 === t || "number" == typeof t && t > 0 && t - 1 in e
            }
            function i(e, t, n) {
                if (Z.isFunction(t)) return Z.grep(e,
                function (e, i) {
                    return !!t.call(e, i, e) !== n
                });
                if (t.nodeType) return Z.grep(e,
                function (e) {
                    return e === t !== n
                });
                if ("string" == typeof t) {
                    if (se.test(t)) return Z.filter(t, e, n);
                    t = Z.filter(t, e)
                }
                return Z.grep(e,
                function (e) {
                    return U.call(t, e) >= 0 !== n
                })
            }
            function r(e, t) {
                for (; (e = e[t]) && 1 !== e.nodeType;);
                return e
            }
            function o(e) {
                var t = he[e] = {};
                return Z.each(e.match(pe) || [],
                function (e, n) {
                    t[n] = !0
                }),
                t
            }
            function a() {
                Y.removeEventListener("DOMContentLoaded", a, !1),
                e.removeEventListener("load", a, !1),
                Z.ready()
            }
            function s() {
                Object.defineProperty(this.cache = {},
                0, {
                    get: function () {
                        return {}
                    }
                }),
                this.expando = Z.expando + s.uid++
            }
            function u(e, t, n) {
                var i;
                if (void 0 === n && 1 === e.nodeType) if (i = "data-" + t.replace(we, "-$1").toLowerCase(), n = e.getAttribute(i), "string" == typeof n) {
                    try {
                        n = "true" === n ? !0 : "false" === n ? !1 : "null" === n ? null : +n + "" === n ? +n : xe.test(n) ? Z.parseJSON(n) : n
                    } catch (r) { }
                    ye.set(e, t, n)
                } else n = void 0;
                return n
            }
            function c() {
                return !0
            }
            function l() {
                return !1
            }
            function f() {
                try {
                    return Y.activeElement
                } catch (e) { }
            }
            function d(e, t) {
                return Z.nodeName(e, "table") && Z.nodeName(11 !== t.nodeType ? t : t.firstChild, "tr") ? e.getElementsByTagName("tbody")[0] || e.appendChild(e.ownerDocument.createElement("tbody")) : e
            }
            function p(e) {
                return e.type = (null !== e.getAttribute("type")) + "/" + e.type,
                e
            }
            function h(e) {
                var t = Me.exec(e.type);
                return t ? e.type = t[1] : e.removeAttribute("type"),
                e
            }
            function g(e, t) {
                for (var n = 0,
                i = e.length; i > n; n++) ve.set(e[n], "globalEval", !t || ve.get(t[n], "globalEval"))
            }
            function m(e, t) {
                var n, i, r, o, a, s, u, c;
                if (1 === t.nodeType) {
                    if (ve.hasData(e) && (o = ve.access(e), a = ve.set(t, o), c = o.events)) {
                        delete a.handle,
                        a.events = {};
                        for (r in c) for (n = 0, i = c[r].length; i > n; n++) Z.event.add(t, r, c[r][n])
                    }
                    ye.hasData(e) && (s = ye.access(e), u = Z.extend({},
                    s), ye.set(t, u))
                }
            }
            function v(e, t) {
                var n = e.getElementsByTagName ? e.getElementsByTagName(t || "*") : e.querySelectorAll ? e.querySelectorAll(t || "*") : [];
                return void 0 === t || t && Z.nodeName(e, t) ? Z.merge([e], n) : n
            }
            function y(e, t) {
                var n = t.nodeName.toLowerCase();
                "input" === n && Se.test(e.type) ? t.checked = e.checked : ("input" === n || "textarea" === n) && (t.defaultValue = e.defaultValue)
            }
            function x(t, n) {
                var i, r = Z(n.createElement(t)).appendTo(n.body),
                o = e.getDefaultComputedStyle && (i = e.getDefaultComputedStyle(r[0])) ? i.display : Z.css(r[0], "display");
                return r.detach(),
                o
            }
            function w(e) {
                var t = Y,
                n = He[e];
                return n || (n = x(e, t), "none" !== n && n || (Re = (Re || Z("<iframe frameborder='0' width='0' height='0'/>")).appendTo(t.documentElement), t = Re[0].contentDocument, t.write(), t.close(), n = x(e, t), Re.detach()), He[e] = n),
                n
            }
            function b(e, t, n) {
                var i, r, o, a, s = e.style;
                return n = n || We(e),
                n && (a = n.getPropertyValue(t) || n[t]),
                n && ("" !== a || Z.contains(e.ownerDocument, e) || (a = Z.style(e, t)), Be.test(a) && Fe.test(t) && (i = s.width, r = s.minWidth, o = s.maxWidth, s.minWidth = s.maxWidth = s.width = a, a = n.width, s.width = i, s.minWidth = r, s.maxWidth = o)),
                void 0 !== a ? a + "" : a
            }
            function k(e, t) {
                return {
                    get: function () {
                        return e() ? void delete this.get : (this.get = t).apply(this, arguments)
                    }
                }
            }
            function T(e, t) {
                if (t in e) return t;
                for (var n = t[0].toUpperCase() + t.slice(1), i = t, r = Ge.length; r--;) if (t = Ge[r] + n, t in e) return t;
                return i
            }
            function S(e, t, n) {
                var i = ze.exec(t);
                return i ? Math.max(0, i[1] - (n || 0)) + (i[2] || "px") : t
            }
            function C(e, t, n, i, r) {
                for (var o = n === (i ? "border" : "content") ? 4 : "width" === t ? 1 : 0, a = 0; 4 > o; o += 2) "margin" === n && (a += Z.css(e, n + ke[o], !0, r)),
                i ? ("content" === n && (a -= Z.css(e, "padding" + ke[o], !0, r)), "margin" !== n && (a -= Z.css(e, "border" + ke[o] + "Width", !0, r))) : (a += Z.css(e, "padding" + ke[o], !0, r), "padding" !== n && (a += Z.css(e, "border" + ke[o] + "Width", !0, r)));
                return a
            }
            function _(e, t, n) {
                var i = !0,
                r = "width" === t ? e.offsetWidth : e.offsetHeight,
                o = We(e),
                a = "border-box" === Z.css(e, "boxSizing", !1, o);
                if (0 >= r || null == r) {
                    if (r = b(e, t, o), (0 > r || null == r) && (r = e.style[t]), Be.test(r)) return r;
                    i = a && (Q.boxSizingReliable() || r === e.style[t]),
                    r = parseFloat(r) || 0
                }
                return r + C(e, t, n || (a ? "border" : "content"), i, o) + "px"
            }
            function j(e, t) {
                for (var n, i, r, o = [], a = 0, s = e.length; s > a; a++) i = e[a],
                i.style && (o[a] = ve.get(i, "olddisplay"), n = i.style.display, t ? (o[a] || "none" !== n || (i.style.display = ""), "" === i.style.display && Te(i) && (o[a] = ve.access(i, "olddisplay", w(i.nodeName)))) : (r = Te(i), "none" === n && r || ve.set(i, "olddisplay", r ? n : Z.css(i, "display"))));
                for (a = 0; s > a; a++) i = e[a],
                i.style && (t && "none" !== i.style.display && "" !== i.style.display || (i.style.display = t ? o[a] || "" : "none"));
                return e
            }
            function E(e, t, n, i, r) {
                return new E.prototype.init(e, t, n, i, r)
            }
            function N() {
                return setTimeout(function () {
                    Qe = void 0
                }),
                Qe = Z.now()
            }
            function A(e, t) {
                var n, i = 0,
                r = {
                    height: e
                };
                for (t = t ? 1 : 0; 4 > i; i += 2 - t) n = ke[i],
                r["margin" + n] = r["padding" + n] = e;
                return t && (r.opacity = r.width = e),
                r
            }
            function O(e, t, n) {
                for (var i, r = (nt[t] || []).concat(nt["*"]), o = 0, a = r.length; a > o; o++) if (i = r[o].call(n, t, e)) return i
            }
            function D(e, t, n) {
                var i, r, o, a, s, u, c, l, f = this,
                d = {},
                p = e.style,
                h = e.nodeType && Te(e),
                g = ve.get(e, "fxshow");
                n.queue || (s = Z._queueHooks(e, "fx"), null == s.unqueued && (s.unqueued = 0, u = s.empty.fire, s.empty.fire = function () {
                    s.unqueued || u()
                }), s.unqueued++, f.always(function () {
                    f.always(function () {initialize
                        s.unqueued--,
                        Z.queue(e, "fx").length || s.empty.fire()
                    })
                })),
                1 === e.nodeType && ("height" in t || "width" in t) && (n.overflow = [p.overflow, p.overflowX, p.overflowY], c = Z.css(e, "display"), l = "none" === c ? ve.get(e, "olddisplay") || w(e.nodeName) : c, "inline" === l && "none" === Z.css(e, "float") && (p.display = "inline-block")),
                n.overflow && (p.overflow = "hidden", f.always(function () {
                    p.overflow = n.overflow[0],
                    p.overflowX = n.overflow[1],
                    p.overflowY = n.overflow[2]
                }));
                for (i in t) if (r = t[i], Ke.exec(r)) {
                    if (delete t[i], o = o || "toggle" === r, r === (h ? "hide" : "show")) {
                        if ("show" !== r || !g || void 0 === g[i]) continue;
                        h = !0
                    }
                    d[i] = g && g[i] || Z.style(e, i)
                } else c = void 0;
                if (Z.isEmptyObject(d)) "inline" === ("none" === c ? w(e.nodeName) : c) && (p.display = c);
                else {
                    g ? "hidden" in g && (h = g.hidden) : g = ve.access(e, "fxshow", {}),
                    o && (g.hidden = !h),
                    h ? Z(e).show() : f.done(function () {
                        Z(e).hide()
                    }),
                    f.done(function () {
                        var t;
                        ve.remove(e, "fxshow");
                        for (t in d) Z.style(e, t, d[t])
                    });
                    for (i in d) a = O(h ? g[i] : 0, i, f),
                    i in g || (g[i] = a.start, h && (a.end = a.start, a.start = "width" === i || "height" === i ? 1 : 0))
                }
            }
            function I(e, t) {
                var n, i, r, o, a;
                for (n in e) if (i = Z.camelCase(n), r = t[i], o = e[n], Z.isArray(o) && (r = o[1], o = e[n] = o[0]), n !== i && (e[i] = o, delete e[n]), a = Z.cssHooks[i], a && "expand" in a) {
                    o = a.expand(o),
                    delete e[i];
                    for (n in o) n in e || (e[n] = o[n], t[n] = r)
                } else t[i] = r
            }
            function q(e, t, n) {
                var i, r, o = 0,
                a = tt.length,
                s = Z.Deferred().always(function () {
                    delete u.elem
                }),
                u = function () {
                    if (r) return !1;
                    for (var t = Qe || N(), n = Math.max(0, c.startTime + c.duration - t), i = n / c.duration || 0, o = 1 - i, a = 0, u = c.tweens.length; u > a; a++) c.tweens[a].run(o);
                    return s.notifyWith(e, [c, o, n]),
                    1 > o && u ? n : (s.resolveWith(e, [c]), !1)
                },
                c = s.promise({
                    elem: e,
                    props: Z.extend({},
                    t),
                    opts: Z.extend(!0, {
                        specialEasing: {}
                    },
                    n),
                    originalProperties: t,
                    originalOptions: n,
                    startTime: Qe || N(),
                    duration: n.duration,
                    tweens: [],
                    createTween: function (t, n) {
                        var i = Z.Tween(e, c.opts, t, n, c.opts.specialEasing[t] || c.opts.easing);
                        return c.tweens.push(i),
                        i
                    },
                    stop: function (t) {
                        var n = 0,
                        i = t ? c.tweens.length : 0;
                        if (r) return this;
                        for (r = !0; i > n; n++) c.tweens[n].run(1);
                        return t ? s.resolveWith(e, [c, t]) : s.rejectWith(e, [c, t]),
                        this
                    }
                }),
                l = c.props;
                for (I(l, c.opts.specialEasing) ; a > o; o++) if (i = tt[o].call(c, e, l, c.opts)) return i;
                return Z.map(l, O, c),
                Z.isFunction(c.opts.start) && c.opts.start.call(e, c),
                Z.fx.timer(Z.extend(u, {
                    elem: e,
                    anim: c,
                    queue: c.opts.queue
                })),
                c.progress(c.opts.progress).done(c.opts.done, c.opts.complete).fail(c.opts.fail).always(c.opts.always)
            }
            function L(e) {
                return function (t, n) {
                    "string" != typeof t && (n = t, t = "*");
                    var i, r = 0,
                    o = t.toLowerCase().match(pe) || [];
                    if (Z.isFunction(n)) for (; i = o[r++];) "+" === i[0] ? (i = i.slice(1) || "*", (e[i] = e[i] || []).unshift(n)) : (e[i] = e[i] || []).push(n)
                }
            }
            function M(e, t, n, i) {
                function r(s) {
                    var u;
                    return o[s] = !0,
                    Z.each(e[s] || [],
                    function (e, s) {
                        var c = s(t, n, i);
                        return "string" != typeof c || a || o[c] ? a ? !(u = c) : void 0 : (t.dataTypes.unshift(c), r(c), !1)
                    }),
                    u
                }
                var o = {},
                a = e === xt;
                return r(t.dataTypes[0]) || !o["*"] && r("*")
            }
            function $(e, t) {
                var n, i, r = Z.ajaxSettings.flatOptions || {};
                for (n in t) void 0 !== t[n] && ((r[n] ? e : i || (i = {}))[n] = t[n]);
                return i && Z.extend(!0, e, i),
                e
            }
            function P(e, t, n) {
                for (var i, r, o, a, s = e.contents,
                u = e.dataTypes;
                "*" === u[0];) u.shift(),
                void 0 === i && (i = e.mimeType || t.getResponseHeader("Content-Type"));
                if (i) for (r in s) if (s[r] && s[r].test(i)) {
                    u.unshift(r);
                    break
                }
                if (u[0] in n) o = u[0];
                else {
                    for (r in n) {
                        if (!u[0] || e.converters[r + " " + u[0]]) {
                            o = r;
                            break
                        }
                        a || (a = r)
                    }
                    o = o || a
                }
                return o ? (o !== u[0] && u.unshift(o), n[o]) : void 0
            }
            function R(e, t, n, i) {
                var r, o, a, s, u, c = {},
                l = e.dataTypes.slice();
                if (l[1]) for (a in e.converters) c[a.toLowerCase()] = e.converters[a];
                for (o = l.shift() ; o;) if (e.responseFields[o] && (n[e.responseFields[o]] = t), !u && i && e.dataFilter && (t = e.dataFilter(t, e.dataType)), u = o, o = l.shift()) if ("*" === o) o = u;
                else if ("*" !== u && u !== o) {
                    if (a = c[u + " " + o] || c["* " + o], !a) for (r in c) if (s = r.split(" "), s[1] === o && (a = c[u + " " + s[0]] || c["* " + s[0]])) {
                        a === !0 ? a = c[r] : c[r] !== !0 && (o = s[0], l.unshift(s[1]));
                        break
                    }
                    if (a !== !0) if (a && e["throws"]) t = a(t);
                    else try {
                        t = a(t)
                    } catch (f) {
                        return {
                            state: "parsererror",
                            error: a ? f : "No conversion from " + u + " to " + o
                        }
                    }
                }
                return {
                    state: "success",
                    data: t
                }
            }
            function H(e, t, n, i) {
                var r;
                if (Z.isArray(t)) Z.each(t,
                function (t, r) {
                    n || St.test(e) ? i(e, r) : H(e + "[" + ("object" == typeof r ? t : "") + "]", r, n, i)
                });
                else if (n || "object" !== Z.type(t)) i(e, t);
                else for (r in t) H(e + "[" + r + "]", t[r], n, i)
            }
            function F(e) {
                return Z.isWindow(e) ? e : 9 === e.nodeType && e.defaultView
            }
            var B = [],
            W = B.slice,
            V = B.concat,
            z = B.push,
            U = B.indexOf,
            J = {},
            X = J.toString,
            G = J.hasOwnProperty,
            Q = {},
            Y = e.document,
            K = "2.1.4",
            Z = function (e, t) {
                return new Z.fn.init(e, t)
            },
            ee = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g,
            te = /^-ms-/,
            ne = /-([\da-z])/gi,
            ie = function (e, t) {
                return t.toUpperCase()
            };
            Z.fn = Z.prototype = {
                jquery: K,
                constructor: Z,
                selector: "",
                length: 0,
                toArray: function () {
                    return W.call(this)
                },
                get: function (e) {
                    return null != e ? 0 > e ? this[e + this.length] : this[e] : W.call(this)
                },
                pushStack: function (e) {
                    var t = Z.merge(this.constructor(), e);
                    return t.prevObject = this,
                    t.context = this.context,
                    t
                },
                each: function (e, t) {
                    return Z.each(this, e, t)
                },
                map: function (e) {
                    return this.pushStack(Z.map(this,
                    function (t, n) {
                        return e.call(t, n, t)
                    }))
                },
                slice: function () {
                    return this.pushStack(W.apply(this, arguments))
                },
                first: function () {
                    return this.eq(0)
                },
                last: function () {
                    return this.eq(-1)
                },
                eq: function (e) {
                    var t = this.length,
                    n = +e + (0 > e ? t : 0);
                    return this.pushStack(n >= 0 && t > n ? [this[n]] : [])
                },
                end: function () {
                    return this.prevObject || this.constructor(null)
                },
                push: z,
                sort: B.sort,
                splice: B.splice
            },
            Z.extend = Z.fn.extend = function () {
                var e, t, n, i, r, o, a = arguments[0] || {},
                s = 1,
                u = arguments.length,
                c = !1;
                for ("boolean" == typeof a && (c = a, a = arguments[s] || {},
                s++), "object" == typeof a || Z.isFunction(a) || (a = {}), s === u && (a = this, s--) ; u > s; s++) if (null != (e = arguments[s])) for (t in e) n = a[t],
                i = e[t],
                a !== i && (c && i && (Z.isPlainObject(i) || (r = Z.isArray(i))) ? (r ? (r = !1, o = n && Z.isArray(n) ? n : []) : o = n && Z.isPlainObject(n) ? n : {},
                a[t] = Z.extend(c, o, i)) : void 0 !== i && (a[t] = i));
                return a
            },
            Z.extend({
                expando: "jQuery" + (K + Math.random()).replace(/\D/g, ""),
                isReady: !0,
                error: function (e) {
                    throw new Error(e)
                },
                noop: function () { },
                isFunction: function (e) {
                    return "function" === Z.type(e)
                },
                isArray: Array.isArray,
                isWindow: function (e) {
                    return null != e && e === e.window
                },
                isNumeric: function (e) {
                    return !Z.isArray(e) && e - parseFloat(e) + 1 >= 0
                },
                isPlainObject: function (e) {
                    return "object" !== Z.type(e) || e.nodeType || Z.isWindow(e) ? !1 : e.constructor && !G.call(e.constructor.prototype, "isPrototypeOf") ? !1 : !0
                },
                isEmptyObject: function (e) {
                    var t;
                    for (t in e) return !1;
                    return !0
                },
                type: function (e) {
                    return null == e ? e + "" : "object" == typeof e || "function" == typeof e ? J[X.call(e)] || "object" : typeof e
                },
                globalEval: function (e) {
                    var t, n = eval;
                    e = Z.trim(e),
                    e && (1 === e.indexOf("use strict") ? (t = Y.createElement("script"), t.text = e, Y.head.appendChild(t).parentNode.removeChild(t)) : n(e))
                },
                camelCase: function (e) {
                    return e.replace(te, "ms-").replace(ne, ie)
                },
                nodeName: function (e, t) {
                    return e.nodeName && e.nodeName.toLowerCase() === t.toLowerCase()
                },
                each: function (e, t, i) {
                    var r, o = 0,
                    a = e.length,
                    s = n(e);
                    if (i) {
                        if (s) for (; a > o && (r = t.apply(e[o], i), r !== !1) ; o++);
                        else for (o in e) if (r = t.apply(e[o], i), r === !1) break
                    } else if (s) for (; a > o && (r = t.call(e[o], o, e[o]), r !== !1) ; o++);
                    else for (o in e) if (r = t.call(e[o], o, e[o]), r === !1) break;
                    return e
                },
                trim: function (e) {
                    return null == e ? "" : (e + "").replace(ee, "")
                },
                makeArray: function (e, t) {
                    var i = t || [];
                    return null != e && (n(Object(e)) ? Z.merge(i, "string" == typeof e ? [e] : e) : z.call(i, e)),
                    i
                },
                inArray: function (e, t, n) {
                    return null == t ? -1 : U.call(t, e, n)
                },
                merge: function (e, t) {
                    for (var n = +t.length,
                    i = 0,
                    r = e.length; n > i; i++) e[r++] = t[i];
                    return e.length = r,
                    e
                },
                grep: function (e, t, n) {
                    for (var i, r = [], o = 0, a = e.length, s = !n; a > o; o++) i = !t(e[o], o),
                    i !== s && r.push(e[o]);
                    return r
                },
                map: function (e, t, i) {
                    var r, o = 0,
                    a = e.length,
                    s = n(e),
                    u = [];
                    if (s) for (; a > o; o++) r = t(e[o], o, i),
                    null != r && u.push(r);
                    else for (o in e) r = t(e[o], o, i),
                    null != r && u.push(r);
                    return V.apply([], u)
                },
                guid: 1,
                proxy: function (e, t) {
                    var n, i, r;
                    return "string" == typeof t && (n = e[t], t = e, e = n),
                    Z.isFunction(e) ? (i = W.call(arguments, 2), r = function () {
                        return e.apply(t || this, i.concat(W.call(arguments)))
                    },
                    r.guid = e.guid = e.guid || Z.guid++, r) : void 0
                },
                now: Date.now,
                support: Q
            }),
            Z.each("Boolean Number String Function Array Date RegExp Object Error".split(" "),
            function (e, t) {
                J["[object " + t + "]"] = t.toLowerCase()
            });
            var re = function (e) {
                function t(e, t, n, i) {
                    var r, o, a, s, u, c, f, p, h, g;
                    if ((t ? t.ownerDocument || t : H) !== D && O(t), t = t || D, n = n || [], s = t.nodeType, "string" != typeof e || !e || 1 !== s && 9 !== s && 11 !== s) return n;
                    if (!i && q) {
                        if (11 !== s && (r = ye.exec(e))) if (a = r[1]) {
                            if (9 === s) {
                                if (o = t.getElementById(a), !o || !o.parentNode) return n;
                                if (o.id === a) return n.push(o),
                                n
                            } else if (t.ownerDocument && (o = t.ownerDocument.getElementById(a)) && P(t, o) && o.id === a) return n.push(o),
                            n
                        } else {
                            if (r[2]) return K.apply(n, t.getElementsByTagName(e)),
                            n;
                            if ((a = r[3]) && b.getElementsByClassName) return K.apply(n, t.getElementsByClassName(a)),
                            n
                        }
                        if (b.qsa && (!L || !L.test(e))) {
                            if (p = f = R, h = t, g = 1 !== s && e, 1 === s && "object" !== t.nodeName.toLowerCase()) {
                                for (c = C(e), (f = t.getAttribute("id")) ? p = f.replace(we, "\\$&") : t.setAttribute("id", p), p = "[id='" + p + "'] ", u = c.length; u--;) c[u] = p + d(c[u]);
                                h = xe.test(e) && l(t.parentNode) || t,
                                g = c.join(",")
                            }
                            if (g) try {
                                return K.apply(n, h.querySelectorAll(g)),
                                n
                            } catch (m) { } finally {
                                f || t.removeAttribute("id")
                            }
                        }
                    }
                    return j(e.replace(ue, "$1"), t, n, i)
                }
                function n() {
                    function e(n, i) {
                        return t.push(n + " ") > k.cacheLength && delete e[t.shift()],
                        e[n + " "] = i
                    }
                    var t = [];
                    return e
                }
                function i(e) {
                    return e[R] = !0,
                    e
                }
                function r(e) {
                    var t = D.createElement("div");
                    try {
                        return !!e(t)
                    } catch (n) {
                        return !1
                    } finally {
                        t.parentNode && t.parentNode.removeChild(t),
                        t = null
                    }
                }
                function o(e, t) {
                    for (var n = e.split("|"), i = e.length; i--;) k.attrHandle[n[i]] = t
                }
                function a(e, t) {
                    var n = t && e,
                    i = n && 1 === e.nodeType && 1 === t.nodeType && (~t.sourceIndex || J) - (~e.sourceIndex || J);
                    if (i) return i;
                    if (n) for (; n = n.nextSibling;) if (n === t) return -1;
                    return e ? 1 : -1
                }
                function s(e) {
                    return function (t) {
                        var n = t.nodeName.toLowerCase();
                        return "input" === n && t.type === e
                    }
                }
                function u(e) {
                    return function (t) {
                        var n = t.nodeName.toLowerCase();
                        return ("input" === n || "button" === n) && t.type === e
                    }
                }
                function c(e) {
                    return i(function (t) {
                        return t = +t,
                        i(function (n, i) {
                            for (var r, o = e([], n.length, t), a = o.length; a--;) n[r = o[a]] && (n[r] = !(i[r] = n[r]))
                        })
                    })
                }
                function l(e) {
                    return e && "undefined" != typeof e.getElementsByTagName && e
                }
                function f() { }
                function d(e) {
                    for (var t = 0,
                    n = e.length,
                    i = ""; n > t; t++) i += e[t].value;
                    return i
                }
                function p(e, t, n) {
                    var i = t.dir,
                    r = n && "parentNode" === i,
                    o = B++;
                    return t.first ?
                    function (t, n, o) {
                        for (; t = t[i];) if (1 === t.nodeType || r) return e(t, n, o)
                    } : function (t, n, a) {
                        var s, u, c = [F, o];
                        if (a) {
                            for (; t = t[i];) if ((1 === t.nodeType || r) && e(t, n, a)) return !0
                        } else for (; t = t[i];) if (1 === t.nodeType || r) {
                            if (u = t[R] || (t[R] = {}), (s = u[i]) && s[0] === F && s[1] === o) return c[2] = s[2];
                            if (u[i] = c, c[2] = e(t, n, a)) return !0
                        }
                    }
                }
                function h(e) {
                    return e.length > 1 ?
                    function (t, n, i) {
                        for (var r = e.length; r--;) if (!e[r](t, n, i)) return !1;
                        return !0
                    } : e[0]
                }
                function g(e, n, i) {
                    for (var r = 0,
                    o = n.length; o > r; r++) t(e, n[r], i);
                    return i
                }
                function m(e, t, n, i, r) {
                    for (var o, a = [], s = 0, u = e.length, c = null != t; u > s; s++) (o = e[s]) && (!n || n(o, i, r)) && (a.push(o), c && t.push(s));
                    return a
                }
                function v(e, t, n, r, o, a) {
                    return r && !r[R] && (r = v(r)),
                    o && !o[R] && (o = v(o, a)),
                    i(function (i, a, s, u) {
                        var c, l, f, d = [],
                        p = [],
                        h = a.length,
                        v = i || g(t || "*", s.nodeType ? [s] : s, []),
                        y = !e || !i && t ? v : m(v, d, e, s, u),
                        x = n ? o || (i ? e : h || r) ? [] : a : y;
                        if (n && n(y, x, s, u), r) for (c = m(x, p), r(c, [], s, u), l = c.length; l--;) (f = c[l]) && (x[p[l]] = !(y[p[l]] = f));
                        if (i) {
                            if (o || e) {
                                if (o) {
                                    for (c = [], l = x.length; l--;) (f = x[l]) && c.push(y[l] = f);
                                    o(null, x = [], c, u)
                                }
                                for (l = x.length; l--;) (f = x[l]) && (c = o ? ee(i, f) : d[l]) > -1 && (i[c] = !(a[c] = f))
                            }
                        } else x = m(x === a ? x.splice(h, x.length) : x),
                        o ? o(null, a, x, u) : K.apply(a, x)
                    })
                }
                function y(e) {
                    for (var t, n, i, r = e.length,
                    o = k.relative[e[0].type], a = o || k.relative[" "], s = o ? 1 : 0, u = p(function (e) {
                        return e === t
                    },
                    a, !0), c = p(function (e) {
                        return ee(t, e) > -1
                    },
                    a, !0), l = [function (e, n, i) {
                        var r = !o && (i || n !== E) || ((t = n).nodeType ? u(e, n, i) : c(e, n, i));
                        return t = null,
                        r
                    }]; r > s; s++) if (n = k.relative[e[s].type]) l = [p(h(l), n)];
                    else {
                        if (n = k.filter[e[s].type].apply(null, e[s].matches), n[R]) {
                            for (i = ++s; r > i && !k.relative[e[i].type]; i++);
                            return v(s > 1 && h(l), s > 1 && d(e.slice(0, s - 1).concat({
                                value: " " === e[s - 2].type ? "*" : ""
                            })).replace(ue, "$1"), n, i > s && y(e.slice(s, i)), r > i && y(e = e.slice(i)), r > i && d(e))
                        }
                        l.push(n)
                    }
                    return h(l)
                }
                function x(e, n) {
                    var r = n.length > 0,
                    o = e.length > 0,
                    a = function (i, a, s, u, c) {
                        var l, f, d, p = 0,
                        h = "0",
                        g = i && [],
                        v = [],
                        y = E,
                        x = i || o && k.find.TAG("*", c),
                        w = F += null == y ? 1 : Math.random() || .1,
                        b = x.length;
                        for (c && (E = a !== D && a) ; h !== b && null != (l = x[h]) ; h++) {
                            if (o && l) {
                                for (f = 0; d = e[f++];) if (d(l, a, s)) {
                                    u.push(l);
                                    break
                                }
                                c && (F = w)
                            }
                            r && ((l = !d && l) && p--, i && g.push(l))
                        }
                        if (p += h, r && h !== p) {
                            for (f = 0; d = n[f++];) d(g, v, a, s);
                            if (i) {
                                if (p > 0) for (; h--;) g[h] || v[h] || (v[h] = Q.call(u));
                                v = m(v)
                            }
                            K.apply(u, v),
                            c && !i && v.length > 0 && p + n.length > 1 && t.uniqueSort(u)
                        }
                        return c && (F = w, E = y),
                        g
                    };
                    return r ? i(a) : a
                }
                var w, b, k, T, S, C, _, j, E, N, A, O, D, I, q, L, M, $, P, R = "sizzle" + 1 * new Date,
                H = e.document,
                F = 0,
                B = 0,
                W = n(),
                V = n(),
                z = n(),
                U = function (e, t) {
                    return e === t && (A = !0),
                    0
                },
                J = 1 << 31,
                X = {}.hasOwnProperty,
                G = [],
                Q = G.pop,
                Y = G.push,
                K = G.push,
                Z = G.slice,
                ee = function (e, t) {
                    for (var n = 0,
                    i = e.length; i > n; n++) if (e[n] === t) return n;
                    return -1
                },
                te = "checked|selected|async|autofocus|autoplay|controls|defer|disabled|hidden|ismap|loop|multiple|open|readonly|required|scoped",
                ne = "[\\x20\\t\\r\\n\\f]",
                ie = "(?:\\\\.|[\\w-]|[^\\x00-\\xa0])+",
                re = ie.replace("w", "w#"),
                oe = "\\[" + ne + "*(" + ie + ")(?:" + ne + "*([*^$|!~]?=)" + ne + "*(?:'((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\"|(" + re + "))|)" + ne + "*\\]",
                ae = ":(" + ie + ")(?:\\((('((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\")|((?:\\\\.|[^\\\\()[\\]]|" + oe + ")*)|.*)\\)|)",
                se = new RegExp(ne + "+", "g"),
                ue = new RegExp("^" + ne + "+|((?:^|[^\\\\])(?:\\\\.)*)" + ne + "+$", "g"),
                ce = new RegExp("^" + ne + "*," + ne + "*"),
                le = new RegExp("^" + ne + "*([>+~]|" + ne + ")" + ne + "*"),
                fe = new RegExp("=" + ne + "*([^\\]'\"]*?)" + ne + "*\\]", "g"),
                de = new RegExp(ae),
                pe = new RegExp("^" + re + "$"),
                he = {
                    ID: new RegExp("^#(" + ie + ")"),
                    CLASS: new RegExp("^\\.(" + ie + ")"),
                    TAG: new RegExp("^(" + ie.replace("w", "w*") + ")"),
                    ATTR: new RegExp("^" + oe),
                    PSEUDO: new RegExp("^" + ae),
                    CHILD: new RegExp("^:(only|first|last|nth|nth-last)-(child|of-type)(?:\\(" + ne + "*(even|odd|(([+-]|)(\\d*)n|)" + ne + "*(?:([+-]|)" + ne + "*(\\d+)|))" + ne + "*\\)|)", "i"),
                    bool: new RegExp("^(?:" + te + ")$", "i"),
                    needsContext: new RegExp("^" + ne + "*[>+~]|:(even|odd|eq|gt|lt|nth|first|last)(?:\\(" + ne + "*((?:-\\d)?\\d*)" + ne + "*\\)|)(?=[^-]|$)", "i")
                },
                ge = /^(?:input|select|textarea|button)$/i,
                me = /^h\d$/i,
                ve = /^[^{]+\{\s*\[native \w/,
                ye = /^(?:#([\w-]+)|(\w+)|\.([\w-]+))$/,
                xe = /[+~]/,
                we = /'|\\/g,
                be = new RegExp("\\\\([\\da-f]{1,6}" + ne + "?|(" + ne + ")|.)", "ig"),
                ke = function (e, t, n) {
                    var i = "0x" + t - 65536;
                    return i !== i || n ? t : 0 > i ? String.fromCharCode(i + 65536) : String.fromCharCode(i >> 10 | 55296, 1023 & i | 56320)
                },
                Te = function () {
                    O()
                };
                try {
                    K.apply(G = Z.call(H.childNodes), H.childNodes),
                    G[H.childNodes.length].nodeType
                } catch (Se) {
                    K = {
                        apply: G.length ?
                        function (e, t) {
                            Y.apply(e, Z.call(t))
                        } : function (e, t) {
                            for (var n = e.length,
                            i = 0; e[n++] = t[i++];);
                            e.length = n - 1
                        }
                    }
                }
                b = t.support = {},
                S = t.isXML = function (e) {
                    var t = e && (e.ownerDocument || e).documentElement;
                    return t ? "HTML" !== t.nodeName : !1
                },
                O = t.setDocument = function (e) {
                    var t, n, i = e ? e.ownerDocument || e : H;
                    return i !== D && 9 === i.nodeType && i.documentElement ? (D = i, I = i.documentElement, n = i.defaultView, n && n !== n.top && (n.addEventListener ? n.addEventListener("unload", Te, !1) : n.attachEvent && n.attachEvent("onunload", Te)), q = !S(i), b.attributes = r(function (e) {
                        return e.className = "i",
                        !e.getAttribute("className")
                    }), b.getElementsByTagName = r(function (e) {
                        return e.appendChild(i.createComment("")),
                        !e.getElementsByTagName("*").length
                    }), b.getElementsByClassName = ve.test(i.getElementsByClassName), b.getById = r(function (e) {
                        return I.appendChild(e).id = R,
                        !i.getElementsByName || !i.getElementsByName(R).length
                    }), b.getById ? (k.find.ID = function (e, t) {
                        if ("undefined" != typeof t.getElementById && q) {
                            var n = t.getElementById(e);
                            return n && n.parentNode ? [n] : []
                        }
                    },
                    k.filter.ID = function (e) {
                        var t = e.replace(be, ke);
                        return function (e) {
                            return e.getAttribute("id") === t
                        }
                    }) : (delete k.find.ID, k.filter.ID = function (e) {
                        var t = e.replace(be, ke);
                        return function (e) {
                            var n = "undefined" != typeof e.getAttributeNode && e.getAttributeNode("id");
                            return n && n.value === t
                        }
                    }), k.find.TAG = b.getElementsByTagName ?
                    function (e, t) {
                        return "undefined" != typeof t.getElementsByTagName ? t.getElementsByTagName(e) : b.qsa ? t.querySelectorAll(e) : void 0
                    } : function (e, t) {
                        var n, i = [],
                        r = 0,
                        o = t.getElementsByTagName(e);
                        if ("*" === e) {
                            for (; n = o[r++];) 1 === n.nodeType && i.push(n);
                            return i
                        }
                        return o
                    },
                    k.find.CLASS = b.getElementsByClassName &&
                    function (e, t) {
                        return q ? t.getElementsByClassName(e) : void 0
                    },
                    M = [], L = [], (b.qsa = ve.test(i.querySelectorAll)) && (r(function (e) {
                        I.appendChild(e).innerHTML = "<a id='" + R + "'></a><select id='" + R + "-\f]' msallowcapture=''><option selected=''></option></select>",
                        e.querySelectorAll("[msallowcapture^='']").length && L.push("[*^$]=" + ne + "*(?:''|\"\")"),
                        e.querySelectorAll("[selected]").length || L.push("\\[" + ne + "*(?:value|" + te + ")"),
                        e.querySelectorAll("[id~=" + R + "-]").length || L.push("~="),
                        e.querySelectorAll(":checked").length || L.push(":checked"),
                        e.querySelectorAll("a#" + R + "+*").length || L.push(".#.+[+~]")
                    }), r(function (e) {
                        var t = i.createElement("input");
                        t.setAttribute("type", "hidden"),
                        e.appendChild(t).setAttribute("name", "D"),
                        e.querySelectorAll("[name=d]").length && L.push("name" + ne + "*[*^$|!~]?="),
                        e.querySelectorAll(":enabled").length || L.push(":enabled", ":disabled"),
                        e.querySelectorAll("*,:x"),
                        L.push(",.*:")
                    })), (b.matchesSelector = ve.test($ = I.matches || I.webkitMatchesSelector || I.mozMatchesSelector || I.oMatchesSelector || I.msMatchesSelector)) && r(function (e) {
                        b.disconnectedMatch = $.call(e, "div"),
                        $.call(e, "[s!='']:x"),
                        M.push("!=", ae)
                    }), L = L.length && new RegExp(L.join("|")), M = M.length && new RegExp(M.join("|")), t = ve.test(I.compareDocumentPosition), P = t || ve.test(I.contains) ?
                    function (e, t) {
                        var n = 9 === e.nodeType ? e.documentElement : e,
                        i = t && t.parentNode;
                        return e === i || !(!i || 1 !== i.nodeType || !(n.contains ? n.contains(i) : e.compareDocumentPosition && 16 & e.compareDocumentPosition(i)))
                    } : function (e, t) {
                        if (t) for (; t = t.parentNode;) if (t === e) return !0;
                        return !1
                    },
                    U = t ?
                    function (e, t) {
                        if (e === t) return A = !0,
                        0;
                        var n = !e.compareDocumentPosition - !t.compareDocumentPosition;
                        return n ? n : (n = (e.ownerDocument || e) === (t.ownerDocument || t) ? e.compareDocumentPosition(t) : 1, 1 & n || !b.sortDetached && t.compareDocumentPosition(e) === n ? e === i || e.ownerDocument === H && P(H, e) ? -1 : t === i || t.ownerDocument === H && P(H, t) ? 1 : N ? ee(N, e) - ee(N, t) : 0 : 4 & n ? -1 : 1)
                    } : function (e, t) {
                        if (e === t) return A = !0,
                        0;
                        var n, r = 0,
                        o = e.parentNode,
                        s = t.parentNode,
                        u = [e],
                        c = [t];
                        if (!o || !s) return e === i ? -1 : t === i ? 1 : o ? -1 : s ? 1 : N ? ee(N, e) - ee(N, t) : 0;
                        if (o === s) return a(e, t);
                        for (n = e; n = n.parentNode;) u.unshift(n);
                        for (n = t; n = n.parentNode;) c.unshift(n);
                        for (; u[r] === c[r];) r++;
                        return r ? a(u[r], c[r]) : u[r] === H ? -1 : c[r] === H ? 1 : 0
                    },
                    i) : D
                },
                t.matches = function (e, n) {
                    return t(e, null, null, n)
                },
                t.matchesSelector = function (e, n) {
                    if ((e.ownerDocument || e) !== D && O(e), n = n.replace(fe, "='$1']"), !(!b.matchesSelector || !q || M && M.test(n) || L && L.test(n))) try {
                        var i = $.call(e, n);
                        if (i || b.disconnectedMatch || e.document && 11 !== e.document.nodeType) return i
                    } catch (r) { }
                    return t(n, D, null, [e]).length > 0
                },
                t.contains = function (e, t) {
                    return (e.ownerDocument || e) !== D && O(e),
                    P(e, t)
                },
                t.attr = function (e, t) {
                    (e.ownerDocument || e) !== D && O(e);
                    var n = k.attrHandle[t.toLowerCase()],
                    i = n && X.call(k.attrHandle, t.toLowerCase()) ? n(e, t, !q) : void 0;
                    return void 0 !== i ? i : b.attributes || !q ? e.getAttribute(t) : (i = e.getAttributeNode(t)) && i.specified ? i.value : null
                },
                t.error = function (e) {
                    throw new Error("Syntax error, unrecognized expression: " + e)
                },
                t.uniqueSort = function (e) {
                    var t, n = [],
                    i = 0,
                    r = 0;
                    if (A = !b.detectDuplicates, N = !b.sortStable && e.slice(0), e.sort(U), A) {
                        for (; t = e[r++];) t === e[r] && (i = n.push(r));
                        for (; i--;) e.splice(n[i], 1)
                    }
                    return N = null,
                    e
                },
                T = t.getText = function (e) {
                    var t, n = "",
                    i = 0,
                    r = e.nodeType;
                    if (r) {
                        if (1 === r || 9 === r || 11 === r) {
                            if ("string" == typeof e.textContent) return e.textContent;
                            for (e = e.firstChild; e; e = e.nextSibling) n += T(e)
                        } else if (3 === r || 4 === r) return e.nodeValue
                    } else for (; t = e[i++];) n += T(t);
                    return n
                },
                k = t.selectors = {
                    cacheLength: 50,
                    createPseudo: i,
                    match: he,
                    attrHandle: {},
                    find: {},
                    relative: {
                        ">": {
                            dir: "parentNode",
                            first: !0
                        },
                        " ": {
                            dir: "parentNode"
                        },
                        "+": {
                            dir: "previousSibling",
                            first: !0
                        },
                        "~": {
                            dir: "previousSibling"
                        }
                    },
                    preFilter: {
                        ATTR: function (e) {
                            return e[1] = e[1].replace(be, ke),
                            e[3] = (e[3] || e[4] || e[5] || "").replace(be, ke),
                            "~=" === e[2] && (e[3] = " " + e[3] + " "),
                            e.slice(0, 4)
                        },
                        CHILD: function (e) {
                            return e[1] = e[1].toLowerCase(),
                            "nth" === e[1].slice(0, 3) ? (e[3] || t.error(e[0]), e[4] = +(e[4] ? e[5] + (e[6] || 1) : 2 * ("even" === e[3] || "odd" === e[3])), e[5] = +(e[7] + e[8] || "odd" === e[3])) : e[3] && t.error(e[0]),
                            e
                        },
                        PSEUDO: function (e) {
                            var t, n = !e[6] && e[2];
                            return he.CHILD.test(e[0]) ? null : (e[3] ? e[2] = e[4] || e[5] || "" : n && de.test(n) && (t = C(n, !0)) && (t = n.indexOf(")", n.length - t) - n.length) && (e[0] = e[0].slice(0, t), e[2] = n.slice(0, t)), e.slice(0, 3))
                        }
                    },
                    filter: {
                        TAG: function (e) {
                            var t = e.replace(be, ke).toLowerCase();
                            return "*" === e ?
                            function () {
                                return !0
                            } : function (e) {
                                return e.nodeName && e.nodeName.toLowerCase() === t
                            }
                        },
                        CLASS: function (e) {
                            var t = W[e + " "];
                            return t || (t = new RegExp("(^|" + ne + ")" + e + "(" + ne + "|$)")) && W(e,
                            function (e) {
                                return t.test("string" == typeof e.className && e.className || "undefined" != typeof e.getAttribute && e.getAttribute("class") || "")
                            })
                        },
                        ATTR: function (e, n, i) {
                            return function (r) {
                                var o = t.attr(r, e);
                                return null == o ? "!=" === n : n ? (o += "", "=" === n ? o === i : "!=" === n ? o !== i : "^=" === n ? i && 0 === o.indexOf(i) : "*=" === n ? i && o.indexOf(i) > -1 : "$=" === n ? i && o.slice(-i.length) === i : "~=" === n ? (" " + o.replace(se, " ") + " ").indexOf(i) > -1 : "|=" === n ? o === i || o.slice(0, i.length + 1) === i + "-" : !1) : !0
                            }
                        },
                        CHILD: function (e, t, n, i, r) {
                            var o = "nth" !== e.slice(0, 3),
                            a = "last" !== e.slice(-4),
                            s = "of-type" === t;
                            return 1 === i && 0 === r ?
                            function (e) {
                                return !!e.parentNode
                            } : function (t, n, u) {
                                var c, l, f, d, p, h, g = o !== a ? "nextSibling" : "previousSibling",
                                m = t.parentNode,
                                v = s && t.nodeName.toLowerCase(),
                                y = !u && !s;
                                if (m) {
                                    if (o) {
                                        for (; g;) {
                                            for (f = t; f = f[g];) if (s ? f.nodeName.toLowerCase() === v : 1 === f.nodeType) return !1;
                                            h = g = "only" === e && !h && "nextSibling"
                                        }
                                        return !0
                                    }
                                    if (h = [a ? m.firstChild : m.lastChild], a && y) {
                                        for (l = m[R] || (m[R] = {}), c = l[e] || [], p = c[0] === F && c[1], d = c[0] === F && c[2], f = p && m.childNodes[p]; f = ++p && f && f[g] || (d = p = 0) || h.pop() ;) if (1 === f.nodeType && ++d && f === t) {
                                            l[e] = [F, p, d];
                                            break
                                        }
                                    } else if (y && (c = (t[R] || (t[R] = {}))[e]) && c[0] === F) d = c[1];
                                    else for (; (f = ++p && f && f[g] || (d = p = 0) || h.pop()) && ((s ? f.nodeName.toLowerCase() !== v : 1 !== f.nodeType) || !++d || (y && ((f[R] || (f[R] = {}))[e] = [F, d]), f !== t)) ;);
                                    return d -= r,
                                    d === i || d % i === 0 && d / i >= 0
                                }
                            }
                        },
                        PSEUDO: function (e, n) {
                            var r, o = k.pseudos[e] || k.setFilters[e.toLowerCase()] || t.error("unsupported pseudo: " + e);
                            return o[R] ? o(n) : o.length > 1 ? (r = [e, e, "", n], k.setFilters.hasOwnProperty(e.toLowerCase()) ? i(function (e, t) {
                                for (var i, r = o(e, n), a = r.length; a--;) i = ee(e, r[a]),
                                e[i] = !(t[i] = r[a])
                            }) : function (e) {
                                return o(e, 0, r)
                            }) : o
                        }
                    },
                    pseudos: {
                        not: i(function (e) {
                            var t = [],
                            n = [],
                            r = _(e.replace(ue, "$1"));
                            return r[R] ? i(function (e, t, n, i) {
                                for (var o, a = r(e, null, i, []), s = e.length; s--;) (o = a[s]) && (e[s] = !(t[s] = o))
                            }) : function (e, i, o) {
                                return t[0] = e,
                                r(t, null, o, n),
                                t[0] = null,
                                !n.pop()
                            }
                        }),
                        has: i(function (e) {
                            return function (n) {
                                return t(e, n).length > 0
                            }
                        }),
                        contains: i(function (e) {
                            return e = e.replace(be, ke),
                            function (t) {
                                return (t.textContent || t.innerText || T(t)).indexOf(e) > -1
                            }
                        }),
                        lang: i(function (e) {
                            return pe.test(e || "") || t.error("unsupported lang: " + e),
                            e = e.replace(be, ke).toLowerCase(),
                            function (t) {
                                var n;
                                do
                                    if (n = q ? t.lang : t.getAttribute("xml:lang") || t.getAttribute("lang")) return n = n.toLowerCase(),
                                    n === e || 0 === n.indexOf(e + "-");
                                while ((t = t.parentNode) && 1 === t.nodeType);
                                return !1
                            }
                        }),
                        target: function (t) {
                            var n = e.location && e.location.hash;
                            return n && n.slice(1) === t.id
                        },
                        root: function (e) {
                            return e === I
                        },
                        focus: function (e) {
                            return e === D.activeElement && (!D.hasFocus || D.hasFocus()) && !!(e.type || e.href || ~e.tabIndex)
                        },
                        enabled: function (e) {
                            return e.disabled === !1
                        },
                        disabled: function (e) {
                            return e.disabled === !0
                        },
                        checked: function (e) {
                            var t = e.nodeName.toLowerCase();
                            return "input" === t && !!e.checked || "option" === t && !!e.selected
                        },
                        selected: function (e) {
                            return e.parentNode && e.parentNode.selectedIndex,
                            e.selected === !0
                        },
                        empty: function (e) {
                            for (e = e.firstChild; e; e = e.nextSibling) if (e.nodeType < 6) return !1;
                            return !0
                        },
                        parent: function (e) {
                            return !k.pseudos.empty(e)
                        },
                        header: function (e) {
                            return me.test(e.nodeName)
                        },
                        input: function (e) {
                            return ge.test(e.nodeName)
                        },
                        button: function (e) {
                            var t = e.nodeName.toLowerCase();
                            return "input" === t && "button" === e.type || "button" === t
                        },
                        text: function (e) {
                            var t;
                            return "input" === e.nodeName.toLowerCase() && "text" === e.type && (null == (t = e.getAttribute("type")) || "text" === t.toLowerCase())
                        },
                        first: c(function () {
                            return [0]
                        }),
                        last: c(function (e, t) {
                            return [t - 1]
                        }),
                        eq: c(function (e, t, n) {
                            return [0 > n ? n + t : n]
                        }),
                        even: c(function (e, t) {
                            for (var n = 0; t > n; n += 2) e.push(n);
                            return e
                        }),
                        odd: c(function (e, t) {
                            for (var n = 1; t > n; n += 2) e.push(n);
                            return e
                        }),
                        lt: c(function (e, t, n) {
                            for (var i = 0 > n ? n + t : n; --i >= 0;) e.push(i);
                            return e
                        }),
                        gt: c(function (e, t, n) {
                            for (var i = 0 > n ? n + t : n; ++i < t;) e.push(i);
                            return e
                        })
                    }
                },
                k.pseudos.nth = k.pseudos.eq;
                for (w in {
                    radio: !0,
                    checkbox: !0,
                    file: !0,
                    password: !0,
                    image: !0
                }) k.pseudos[w] = s(w);
                for (w in {
                    submit: !0,
                    reset: !0
                }) k.pseudos[w] = u(w);
                return f.prototype = k.filters = k.pseudos,
                k.setFilters = new f,
                C = t.tokenize = function (e, n) {
                    var i, r, o, a, s, u, c, l = V[e + " "];
                    if (l) return n ? 0 : l.slice(0);
                    for (s = e, u = [], c = k.preFilter; s;) {
                        (!i || (r = ce.exec(s))) && (r && (s = s.slice(r[0].length) || s), u.push(o = [])),
                            i = !1,
                            (r = le.exec(s)) && (i = r.shift(), o.push({
                                value: i,
                                type: r[0].replace(ue, " ")
                            }), s = s.slice(i.length));
                        for (a in k.filter) !(r = he[a].exec(s)) || c[a] && !(r = c[a](r)) || (i = r.shift(), o.push({
                            value: i,
                            type: a,
                            matches: r
                        }), s = s.slice(i.length));
                        if (!i) break
                    }
                    return n ? s.length : s ? t.error(e) : V(e, u).slice(0)
                },
                _ = t.compile = function (e, t) {
                    var n, i = [],
                    r = [],
                    o = z[e + " "];
                    if (!o) {
                        for (t || (t = C(e)), n = t.length; n--;) o = y(t[n]),
                        o[R] ? i.push(o) : r.push(o);
                        o = z(e, x(r, i)),
                        o.selector = e
                    }
                    return o
                },
                j = t.select = function (e, t, n, i) {
                    var r, o, a, s, u, c = "function" == typeof e && e,
                    f = !i && C(e = c.selector || e);
                    if (n = n || [], 1 === f.length) {
                        if (o = f[0] = f[0].slice(0), o.length > 2 && "ID" === (a = o[0]).type && b.getById && 9 === t.nodeType && q && k.relative[o[1].type]) {
                            if (t = (k.find.ID(a.matches[0].replace(be, ke), t) || [])[0], !t) return n;
                            c && (t = t.parentNode),
                            e = e.slice(o.shift().value.length)
                        }
                        for (r = he.needsContext.test(e) ? 0 : o.length; r-- && (a = o[r], !k.relative[s = a.type]) ;) if ((u = k.find[s]) && (i = u(a.matches[0].replace(be, ke), xe.test(o[0].type) && l(t.parentNode) || t))) {
                            if (o.splice(r, 1), e = i.length && d(o), !e) return K.apply(n, i),
                            n;
                            break
                        }
                    }
                    return (c || _(e, f))(i, t, !q, n, xe.test(e) && l(t.parentNode) || t),
                    n
                },
                b.sortStable = R.split("").sort(U).join("") === R,
                b.detectDuplicates = !!A,
                O(),
                b.sortDetached = r(function (e) {
                    return 1 & e.compareDocumentPosition(D.createElement("div"))
                }),
                r(function (e) {
                    return e.innerHTML = "<a href='#'></a>",
                    "#" === e.firstChild.getAttribute("href")
                }) || o("type|href|height|width",
                function (e, t, n) {
                    return n ? void 0 : e.getAttribute(t, "type" === t.toLowerCase() ? 1 : 2)
                }),
                b.attributes && r(function (e) {
                    return e.innerHTML = "<input/>",
                    e.firstChild.setAttribute("value", ""),
                    "" === e.firstChild.getAttribute("value")
                }) || o("value",
                function (e, t, n) {
                    return n || "input" !== e.nodeName.toLowerCase() ? void 0 : e.defaultValue
                }),
                r(function (e) {
                    return null == e.getAttribute("disabled")
                }) || o(te,
                function (e, t, n) {
                    var i;
                    return n ? void 0 : e[t] === !0 ? t.toLowerCase() : (i = e.getAttributeNode(t)) && i.specified ? i.value : null
                }),
                t
            }(e);
            Z.find = re,
            Z.expr = re.selectors,
            Z.expr[":"] = Z.expr.pseudos,
            Z.unique = re.uniqueSort,
            Z.text = re.getText,
            Z.isXMLDoc = re.isXML,
            Z.contains = re.contains;
            var oe = Z.expr.match.needsContext,
            ae = /^<(\w+)\s*\/?>(?:<\/\1>|)$/,
            se = /^.[^:#\[\.,]*$/;
            Z.filter = function (e, t, n) {
                var i = t[0];
                return n && (e = ":not(" + e + ")"),
                1 === t.length && 1 === i.nodeType ? Z.find.matchesSelector(i, e) ? [i] : [] : Z.find.matches(e, Z.grep(t,
                function (e) {
                    return 1 === e.nodeType
                }))
            },
            Z.fn.extend({
                find: function (e) {
                    var t, n = this.length,
                    i = [],
                    r = this;
                    if ("string" != typeof e) return this.pushStack(Z(e).filter(function () {
                        for (t = 0; n > t; t++) if (Z.contains(r[t], this)) return !0
                    }));
                    for (t = 0; n > t; t++) Z.find(e, r[t], i);
                    return i = this.pushStack(n > 1 ? Z.unique(i) : i),
                    i.selector = this.selector ? this.selector + " " + e : e,
                    i
                },
                filter: function (e) {
                    return this.pushStack(i(this, e || [], !1))
                },
                not: function (e) {
                    return this.pushStack(i(this, e || [], !0))
                },
                is: function (e) {
                    return !!i(this, "string" == typeof e && oe.test(e) ? Z(e) : e || [], !1).length
                }
            });
            var ue, ce = /^(?:\s*(<[\w\W]+>)[^>]*|#([\w-]*))$/,
            le = Z.fn.init = function (e, t) {
                var n, i;
                if (!e) return this;
                if ("string" == typeof e) {
                    if (n = "<" === e[0] && ">" === e[e.length - 1] && e.length >= 3 ? [null, e, null] : ce.exec(e), !n || !n[1] && t) return !t || t.jquery ? (t || ue).find(e) : this.constructor(t).find(e);
                    if (n[1]) {
                        if (t = t instanceof Z ? t[0] : t, Z.merge(this, Z.parseHTML(n[1], t && t.nodeType ? t.ownerDocument || t : Y, !0)), ae.test(n[1]) && Z.isPlainObject(t)) for (n in t) Z.isFunction(this[n]) ? this[n](t[n]) : this.attr(n, t[n]);
                        return this
                    }
                    return i = Y.getElementById(n[2]),
                    i && i.parentNode && (this.length = 1, this[0] = i),
                    this.context = Y,
                    this.selector = e,
                    this
                }
                return e.nodeType ? (this.context = this[0] = e, this.length = 1, this) : Z.isFunction(e) ? "undefined" != typeof ue.ready ? ue.ready(e) : e(Z) : (void 0 !== e.selector && (this.selector = e.selector, this.context = e.context), Z.makeArray(e, this))
            };
            le.prototype = Z.fn,
            ue = Z(Y);
            var fe = /^(?:parents|prev(?:Until|All))/,
            de = {
                children: !0,
                contents: !0,
                next: !0,
                prev: !0
            };
            Z.extend({
                dir: function (e, t, n) {
                    for (var i = [], r = void 0 !== n; (e = e[t]) && 9 !== e.nodeType;) if (1 === e.nodeType) {
                        if (r && Z(e).is(n)) break;
                        i.push(e)
                    }
                    return i
                },
                sibling: function (e, t) {
                    for (var n = []; e; e = e.nextSibling) 1 === e.nodeType && e !== t && n.push(e);
                    return n
                }
            }),
            Z.fn.extend({
                has: function (e) {
                    var t = Z(e, this),
                    n = t.length;
                    return this.filter(function () {
                        for (var e = 0; n > e; e++) if (Z.contains(this, t[e])) return !0
                    })
                },
                closest: function (e, t) {
                    for (var n, i = 0,
                    r = this.length,
                    o = [], a = oe.test(e) || "string" != typeof e ? Z(e, t || this.context) : 0; r > i; i++) for (n = this[i]; n && n !== t; n = n.parentNode) if (n.nodeType < 11 && (a ? a.index(n) > -1 : 1 === n.nodeType && Z.find.matchesSelector(n, e))) {
                        o.push(n);
                        break
                    }
                    return this.pushStack(o.length > 1 ? Z.unique(o) : o)
                },
                index: function (e) {
                    return e ? "string" == typeof e ? U.call(Z(e), this[0]) : U.call(this, e.jquery ? e[0] : e) : this[0] && this[0].parentNode ? this.first().prevAll().length : -1
                },
                add: function (e, t) {
                    return this.pushStack(Z.unique(Z.merge(this.get(), Z(e, t))))
                },
                addBack: function (e) {
                    return this.add(null == e ? this.prevObject : this.prevObject.filter(e))
                }
            }),
            Z.each({
                parent: function (e) {
                    var t = e.parentNode;
                    return t && 11 !== t.nodeType ? t : null
                },
                parents: function (e) {
                    return Z.dir(e, "parentNode")
                },
                parentsUntil: function (e, t, n) {
                    return Z.dir(e, "parentNode", n)
                },
                next: function (e) {
                    return r(e, "nextSibling")
                },
                prev: function (e) {
                    return r(e, "previousSibling")
                },
                nextAll: function (e) {
                    return Z.dir(e, "nextSibling")
                },
                prevAll: function (e) {
                    return Z.dir(e, "previousSibling")
                },
                nextUntil: function (e, t, n) {
                    return Z.dir(e, "nextSibling", n)
                },
                prevUntil: function (e, t, n) {
                    return Z.dir(e, "previousSibling", n)
                },
                siblings: function (e) {
                    return Z.sibling((e.parentNode || {}).firstChild, e)
                },
                children: function (e) {
                    return Z.sibling(e.firstChild)
                },
                contents: function (e) {
                    return e.contentDocument || Z.merge([], e.childNodes)
                }
            },
            function (e, t) {
                Z.fn[e] = function (n, i) {
                    var r = Z.map(this, t, n);
                    return "Until" !== e.slice(-5) && (i = n),
                    i && "string" == typeof i && (r = Z.filter(i, r)),
                    this.length > 1 && (de[e] || Z.unique(r), fe.test(e) && r.reverse()),
                    this.pushStack(r)
                }
            });
            var pe = /\S+/g,
            he = {};
            Z.Callbacks = function (e) {
                e = "string" == typeof e ? he[e] || o(e) : Z.extend({},
                e);
                var t, n, i, r, a, s, u = [],
                c = !e.once && [],
                l = function (o) {
                    for (t = e.memory && o, n = !0, s = r || 0, r = 0, a = u.length, i = !0; u && a > s; s++) if (u[s].apply(o[0], o[1]) === !1 && e.stopOnFalse) {
                        t = !1;
                        break
                    }
                    i = !1,
                    u && (c ? c.length && l(c.shift()) : t ? u = [] : f.disable())
                },
                f = {
                    add: function () {
                        if (u) {
                            var n = u.length; !
                            function o(t) {
                                Z.each(t,
                                function (t, n) {
                                    var i = Z.type(n);
                                    "function" === i ? e.unique && f.has(n) || u.push(n) : n && n.length && "string" !== i && o(n)
                                })
                            }(arguments),
                            i ? a = u.length : t && (r = n, l(t))
                        }
                        return this
                    },
                    remove: function () {
                        return u && Z.each(arguments,
                        function (e, t) {
                            for (var n; (n = Z.inArray(t, u, n)) > -1;) u.splice(n, 1),
                            i && (a >= n && a--, s >= n && s--)
                        }),
                        this
                    },
                    has: function (e) {
                        return e ? Z.inArray(e, u) > -1 : !(!u || !u.length)
                    },
                    empty: function () {
                        return u = [],
                        a = 0,
                        this
                    },
                    disable: function () {
                        return u = c = t = void 0,
                        this
                    },
                    disabled: function () {
                        return !u
                    },
                    lock: function () {
                        return c = void 0,
                        t || f.disable(),
                        this
                    },
                    locked: function () {
                        return !c
                    },
                    fireWith: function (e, t) {
                        return !u || n && !c || (t = t || [], t = [e, t.slice ? t.slice() : t], i ? c.push(t) : l(t)),
                        this
                    },
                    fire: function () {
                        return f.fireWith(this, arguments),
                        this
                    },
                    fired: function () {
                        return !!n
                    }
                };
                return f
            },
            Z.extend({
                Deferred: function (e) {
                    var t = [["resolve", "done", Z.Callbacks("once memory"), "resolved"], ["reject", "fail", Z.Callbacks("once memory"), "rejected"], ["notify", "progress", Z.Callbacks("memory")]],
                    n = "pending",
                    i = {
                        state: function () {
                            return n
                        },
                        always: function () {
                            return r.done(arguments).fail(arguments),
                            this
                        },
                        then: function () {
                            var e = arguments;
                            return Z.Deferred(function (n) {
                                Z.each(t,
                                function (t, o) {
                                    var a = Z.isFunction(e[t]) && e[t];
                                    r[o[1]](function () {
                                        var e = a && a.apply(this, arguments);
                                        e && Z.isFunction(e.promise) ? e.promise().done(n.resolve).fail(n.reject).progress(n.notify) : n[o[0] + "With"](this === i ? n.promise() : this, a ? [e] : arguments)
                                    })
                                }),
                                e = null
                            }).promise()
                        },
                        promise: function (e) {
                            return null != e ? Z.extend(e, i) : i
                        }
                    },
                    r = {};
                    return i.pipe = i.then,
                    Z.each(t,
                    function (e, o) {
                        var a = o[2],
                        s = o[3];
                        i[o[1]] = a.add,
                        s && a.add(function () {
                            n = s
                        },
                        t[1 ^ e][2].disable, t[2][2].lock),
                        r[o[0]] = function () {
                            return r[o[0] + "With"](this === r ? i : this, arguments),
                            this
                        },
                        r[o[0] + "With"] = a.fireWith
                    }),
                    i.promise(r),
                    e && e.call(r, r),
                    r
                },
                when: function (e) {
                    var t, n, i, r = 0,
                    o = W.call(arguments),
                    a = o.length,
                    s = 1 !== a || e && Z.isFunction(e.promise) ? a : 0,
                    u = 1 === s ? e : Z.Deferred(),
                    c = function (e, n, i) {
                        return function (r) {
                            n[e] = this,
                            i[e] = arguments.length > 1 ? W.call(arguments) : r,
                            i === t ? u.notifyWith(n, i) : --s || u.resolveWith(n, i)
                        }
                    };
                    if (a > 1) for (t = new Array(a), n = new Array(a), i = new Array(a) ; a > r; r++) o[r] && Z.isFunction(o[r].promise) ? o[r].promise().done(c(r, i, o)).fail(u.reject).progress(c(r, n, t)) : --s;
                    return s || u.resolveWith(i, o),
                    u.promise()
                }
            });
            var ge;
            Z.fn.ready = function (e) {
                return Z.ready.promise().done(e),
                this
            },
            Z.extend({
                isReady: !1,
                readyWait: 1,
                holdReady: function (e) {
                    e ? Z.readyWait++ : Z.ready(!0)
                },
                ready: function (e) {
                    (e === !0 ? --Z.readyWait : Z.isReady) || (Z.isReady = !0, e !== !0 && --Z.readyWait > 0 || (ge.resolveWith(Y, [Z]), Z.fn.triggerHandler && (Z(Y).triggerHandler("ready"), Z(Y).off("ready"))))
                }
            }),
            Z.ready.promise = function (t) {
                return ge || (ge = Z.Deferred(), "complete" === Y.readyState ? setTimeout(Z.ready) : (Y.addEventListener("DOMContentLoaded", a, !1), e.addEventListener("load", a, !1))),
                ge.promise(t)
            },
            Z.ready.promise();
            var me = Z.access = function (e, t, n, i, r, o, a) {
                var s = 0,
                u = e.length,
                c = null == n;
                if ("object" === Z.type(n)) {
                    r = !0;
                    for (s in n) Z.access(e, t, s, n[s], !0, o, a)
                } else if (void 0 !== i && (r = !0, Z.isFunction(i) || (a = !0), c && (a ? (t.call(e, i), t = null) : (c = t, t = function (e, t, n) {
                    return c.call(Z(e), n)
                })), t)) for (; u > s; s++) t(e[s], n, a ? i : i.call(e[s], s, t(e[s], n)));
                return r ? e : c ? t.call(e) : u ? t(e[0], n) : o
            };
            Z.acceptData = function (e) {
                return 1 === e.nodeType || 9 === e.nodeType || !+e.nodeType
            },
            s.uid = 1,
            s.accepts = Z.acceptData,
            s.prototype = {
                key: function (e) {
                    if (!s.accepts(e)) return 0;
                    var t = {},
                    n = e[this.expando];
                    if (!n) {
                        n = s.uid++;
                        try {
                            t[this.expando] = {
                                value: n
                            },
                            Object.defineProperties(e, t)
                        } catch (i) {
                            t[this.expando] = n,
                            Z.extend(e, t)
                        }
                    }
                    return this.cache[n] || (this.cache[n] = {}),
                    n
                },
                set: function (e, t, n) {
                    var i, r = this.key(e),
                    o = this.cache[r];
                    if ("string" == typeof t) o[t] = n;
                    else if (Z.isEmptyObject(o)) Z.extend(this.cache[r], t);
                    else for (i in t) o[i] = t[i];
                    return o
                },
                get: function (e, t) {
                    var n = this.cache[this.key(e)];
                    return void 0 === t ? n : n[t]
                },
                access: function (e, t, n) {
                    var i;
                    return void 0 === t || t && "string" == typeof t && void 0 === n ? (i = this.get(e, t), void 0 !== i ? i : this.get(e, Z.camelCase(t))) : (this.set(e, t, n), void 0 !== n ? n : t)
                },
                remove: function (e, t) {
                    var n, i, r, o = this.key(e),
                    a = this.cache[o];
                    if (void 0 === t) this.cache[o] = {};
                    else {
                        Z.isArray(t) ? i = t.concat(t.map(Z.camelCase)) : (r = Z.camelCase(t), t in a ? i = [t, r] : (i = r, i = i in a ? [i] : i.match(pe) || [])),
                        n = i.length;
                        for (; n--;) delete a[i[n]]
                    }
                },
                hasData: function (e) {
                    return !Z.isEmptyObject(this.cache[e[this.expando]] || {})
                },
                discard: function (e) {
                    e[this.expando] && delete this.cache[e[this.expando]]
                }
            };
            var ve = new s,
            ye = new s,
            xe = /^(?:\{[\w\W]*\}|\[[\w\W]*\])$/,
            we = /([A-Z])/g;
            Z.extend({
                hasData: function (e) {
                    return ye.hasData(e) || ve.hasData(e)
                },
                data: function (e, t, n) {
                    return ye.access(e, t, n)
                },
                removeData: function (e, t) {
                    ye.remove(e, t)
                },
                _data: function (e, t, n) {
                    return ve.access(e, t, n)
                },
                _removeData: function (e, t) {
                    ve.remove(e, t)
                }
            }),
            Z.fn.extend({
                data: function (e, t) {
                    var n, i, r, o = this[0],
                    a = o && o.attributes;
                    if (void 0 === e) {
                        if (this.length && (r = ye.get(o), 1 === o.nodeType && !ve.get(o, "hasDataAttrs"))) {
                            for (n = a.length; n--;) a[n] && (i = a[n].name, 0 === i.indexOf("data-") && (i = Z.camelCase(i.slice(5)), u(o, i, r[i])));
                            ve.set(o, "hasDataAttrs", !0)
                        }
                        return r
                    }
                    return "object" == typeof e ? this.each(function () {
                        ye.set(this, e)
                    }) : me(this,
                    function (t) {
                        var n, i = Z.camelCase(e);
                        if (o && void 0 === t) {
                            if (n = ye.get(o, e), void 0 !== n) return n;
                            if (n = ye.get(o, i), void 0 !== n) return n;
                            if (n = u(o, i, void 0), void 0 !== n) return n
                        } else this.each(function () {
                            var n = ye.get(this, i);
                            ye.set(this, i, t),
                            -1 !== e.indexOf("-") && void 0 !== n && ye.set(this, e, t)
                        })
                    },
                    null, t, arguments.length > 1, null, !0)
                },
                removeData: function (e) {
                    return this.each(function () {
                        ye.remove(this, e)
                    })
                }
            }),
            Z.extend({
                queue: function (e, t, n) {
                    var i;
                    return e ? (t = (t || "fx") + "queue", i = ve.get(e, t), n && (!i || Z.isArray(n) ? i = ve.access(e, t, Z.makeArray(n)) : i.push(n)), i || []) : void 0
                },
                dequeue: function (e, t) {
                    t = t || "fx";
                    var n = Z.queue(e, t),
                    i = n.length,
                    r = n.shift(),
                    o = Z._queueHooks(e, t),
                    a = function () {
                        Z.dequeue(e, t)
                    };
                    "inprogress" === r && (r = n.shift(), i--),
                    r && ("fx" === t && n.unshift("inprogress"), delete o.stop, r.call(e, a, o)),
                    !i && o && o.empty.fire()
                },
                _queueHooks: function (e, t) {
                    var n = t + "queueHooks";
                    return ve.get(e, n) || ve.access(e, n, {
                        empty: Z.Callbacks("once memory").add(function () {
                            ve.remove(e, [t + "queue", n])
                        })
                    })
                }
            }),
            Z.fn.extend({
                queue: function (e, t) {
                    var n = 2;
                    return "string" != typeof e && (t = e, e = "fx", n--),
                    arguments.length < n ? Z.queue(this[0], e) : void 0 === t ? this : this.each(function () {
                        var n = Z.queue(this, e, t);
                        Z._queueHooks(this, e),
                        "fx" === e && "inprogress" !== n[0] && Z.dequeue(this, e)
                    })
                },
                dequeue: function (e) {
                    return this.each(function () {
                        Z.dequeue(this, e)
                    })
                },
                clearQueue: function (e) {
                    return this.queue(e || "fx", [])
                },
                promise: function (e, t) {
                    var n, i = 1,
                    r = Z.Deferred(),
                    o = this,
                    a = this.length,
                    s = function () {
                        --i || r.resolveWith(o, [o])
                    };
                    for ("string" != typeof e && (t = e, e = void 0), e = e || "fx"; a--;) n = ve.get(o[a], e + "queueHooks"),
                    n && n.empty && (i++, n.empty.add(s));
                    return s(),
                    r.promise(t)
                }
            });
            var be = /[+-]?(?:\d*\.|)\d+(?:[eE][+-]?\d+|)/.source,
            ke = ["Top", "Right", "Bottom", "Left"],
            Te = function (e, t) {
                return e = t || e,
                "none" === Z.css(e, "display") || !Z.contains(e.ownerDocument, e)
            },
            Se = /^(?:checkbox|radio)$/i; !
            function () {
                var e = Y.createDocumentFragment(),
                t = e.appendChild(Y.createElement("div")),
                n = Y.createElement("input");
                n.setAttribute("type", "radio"),
                n.setAttribute("checked", "checked"),
                n.setAttribute("name", "t"),
                t.appendChild(n),
                Q.checkClone = t.cloneNode(!0).cloneNode(!0).lastChild.checked,
                t.innerHTML = "<textarea>x</textarea>",
                Q.noCloneChecked = !!t.cloneNode(!0).lastChild.defaultValue
            }();
            var Ce = "undefined";
            Q.focusinBubbles = "onfocusin" in e;
            var _e = /^key/,
            je = /^(?:mouse|pointer|contextmenu)|click/,
            Ee = /^(?:focusinfocus|focusoutblur)$/,
            Ne = /^([^.]*)(?:\.(.+)|)$/;
            Z.event = {
                global: {},
                add: function (e, t, n, i, r) {
                    var o, a, s, u, c, l, f, d, p, h, g, m = ve.get(e);
                    if (m) for (n.handler && (o = n, n = o.handler, r = o.selector), n.guid || (n.guid = Z.guid++), (u = m.events) || (u = m.events = {}), (a = m.handle) || (a = m.handle = function (t) {
                        return typeof Z !== Ce && Z.event.triggered !== t.type ? Z.event.dispatch.apply(e, arguments) : void 0
                    }), t = (t || "").match(pe) || [""], c = t.length; c--;) s = Ne.exec(t[c]) || [],
                    p = g = s[1],
                    h = (s[2] || "").split(".").sort(),
                    p && (f = Z.event.special[p] || {},
                    p = (r ? f.delegateType : f.bindType) || p, f = Z.event.special[p] || {},
                    l = Z.extend({
                        type: p,
                        origType: g,
                        data: i,
                        handler: n,
                        guid: n.guid,
                        selector: r,
                        needsContext: r && Z.expr.match.needsContext.test(r),
                        namespace: h.join(".")
                    },
                    o), (d = u[p]) || (d = u[p] = [], d.delegateCount = 0, f.setup && f.setup.call(e, i, h, a) !== !1 || e.addEventListener && e.addEventListener(p, a, !1)), f.add && (f.add.call(e, l), l.handler.guid || (l.handler.guid = n.guid)), r ? d.splice(d.delegateCount++, 0, l) : d.push(l), Z.event.global[p] = !0)
                },
                remove: function (e, t, n, i, r) {
                    var o, a, s, u, c, l, f, d, p, h, g, m = ve.hasData(e) && ve.get(e);
                    if (m && (u = m.events)) {
                        for (t = (t || "").match(pe) || [""], c = t.length; c--;) if (s = Ne.exec(t[c]) || [], p = g = s[1], h = (s[2] || "").split(".").sort(), p) {
                            for (f = Z.event.special[p] || {},
                            p = (i ? f.delegateType : f.bindType) || p, d = u[p] || [], s = s[2] && new RegExp("(^|\\.)" + h.join("\\.(?:.*\\.|)") + "(\\.|$)"), a = o = d.length; o--;) l = d[o],
                            !r && g !== l.origType || n && n.guid !== l.guid || s && !s.test(l.namespace) || i && i !== l.selector && ("**" !== i || !l.selector) || (d.splice(o, 1), l.selector && d.delegateCount--, f.remove && f.remove.call(e, l));
                            a && !d.length && (f.teardown && f.teardown.call(e, h, m.handle) !== !1 || Z.removeEvent(e, p, m.handle), delete u[p])
                        } else for (p in u) Z.event.remove(e, p + t[c], n, i, !0);
                        Z.isEmptyObject(u) && (delete m.handle, ve.remove(e, "events"))
                    }
                },
                trigger: function (t, n, i, r) {
                    var o, a, s, u, c, l, f, d = [i || Y],
                    p = G.call(t, "type") ? t.type : t,
                    h = G.call(t, "namespace") ? t.namespace.split(".") : [];
                    if (a = s = i = i || Y, 3 !== i.nodeType && 8 !== i.nodeType && !Ee.test(p + Z.event.triggered) && (p.indexOf(".") >= 0 && (h = p.split("."), p = h.shift(), h.sort()), c = p.indexOf(":") < 0 && "on" + p, t = t[Z.expando] ? t : new Z.Event(p, "object" == typeof t && t), t.isTrigger = r ? 2 : 3, t.namespace = h.join("."), t.namespace_re = t.namespace ? new RegExp("(^|\\.)" + h.join("\\.(?:.*\\.|)") + "(\\.|$)") : null, t.result = void 0, t.target || (t.target = i), n = null == n ? [t] : Z.makeArray(n, [t]), f = Z.event.special[p] || {},
                    r || !f.trigger || f.trigger.apply(i, n) !== !1)) {
                        if (!r && !f.noBubble && !Z.isWindow(i)) {
                            for (u = f.delegateType || p, Ee.test(u + p) || (a = a.parentNode) ; a; a = a.parentNode) d.push(a),
                            s = a;
                            s === (i.ownerDocument || Y) && d.push(s.defaultView || s.parentWindow || e)
                        }
                        for (o = 0; (a = d[o++]) && !t.isPropagationStopped() ;) t.type = o > 1 ? u : f.bindType || p,
                        l = (ve.get(a, "events") || {})[t.type] && ve.get(a, "handle"),
                        l && l.apply(a, n),
                        l = c && a[c],
                        l && l.apply && Z.acceptData(a) && (t.result = l.apply(a, n), t.result === !1 && t.preventDefault());
                        return t.type = p,
                        r || t.isDefaultPrevented() || f._default && f._default.apply(d.pop(), n) !== !1 || !Z.acceptData(i) || c && Z.isFunction(i[p]) && !Z.isWindow(i) && (s = i[c], s && (i[c] = null), Z.event.triggered = p, i[p](), Z.event.triggered = void 0, s && (i[c] = s)),
                        t.result
                    }
                },
                dispatch: function (e) {
                    e = Z.event.fix(e);
                    var t, n, i, r, o, a = [],
                    s = W.call(arguments),
                    u = (ve.get(this, "events") || {})[e.type] || [],
                    c = Z.event.special[e.type] || {};
                    if (s[0] = e, e.delegateTarget = this, !c.preDispatch || c.preDispatch.call(this, e) !== !1) {
                        for (a = Z.event.handlers.call(this, e, u), t = 0; (r = a[t++]) && !e.isPropagationStopped() ;) for (e.currentTarget = r.elem, n = 0; (o = r.handlers[n++]) && !e.isImmediatePropagationStopped() ;) (!e.namespace_re || e.namespace_re.test(o.namespace)) && (e.handleObj = o, e.data = o.data, i = ((Z.event.special[o.origType] || {}).handle || o.handler).apply(r.elem, s), void 0 !== i && (e.result = i) === !1 && (e.preventDefault(), e.stopPropagation()));
                        return c.postDispatch && c.postDispatch.call(this, e),
                        e.result
                    }
                },
                handlers: function (e, t) {
                    var n, i, r, o, a = [],
                    s = t.delegateCount,
                    u = e.target;
                    if (s && u.nodeType && (!e.button || "click" !== e.type)) for (; u !== this; u = u.parentNode || this) if (u.disabled !== !0 || "click" !== e.type) {
                        for (i = [], n = 0; s > n; n++) o = t[n],
                        r = o.selector + " ",
                        void 0 === i[r] && (i[r] = o.needsContext ? Z(r, this).index(u) >= 0 : Z.find(r, this, null, [u]).length),
                        i[r] && i.push(o);
                        i.length && a.push({
                            elem: u,
                            handlers: i
                        })
                    }
                    return s < t.length && a.push({
                        elem: this,
                        handlers: t.slice(s)
                    }),
                    a
                },
                props: "altKey bubbles cancelable ctrlKey currentTarget eventPhase metaKey relatedTarget shiftKey target timeStamp view which".split(" "),
                fixHooks: {},
                keyHooks: {
                    props: "char charCode key keyCode".split(" "),
                    filter: function (e, t) {
                        return null == e.which && (e.which = null != t.charCode ? t.charCode : t.keyCode),
                        e
                    }
                },
                mouseHooks: {
                    props: "button buttons clientX clientY offsetX offsetY pageX pageY screenX screenY toElement".split(" "),
                    filter: function (e, t) {
                        var n, i, r, o = t.button;
                        return null == e.pageX && null != t.clientX && (n = e.target.ownerDocument || Y, i = n.documentElement, r = n.body, e.pageX = t.clientX + (i && i.scrollLeft || r && r.scrollLeft || 0) - (i && i.clientLeft || r && r.clientLeft || 0), e.pageY = t.clientY + (i && i.scrollTop || r && r.scrollTop || 0) - (i && i.clientTop || r && r.clientTop || 0)),
                        e.which || void 0 === o || (e.which = 1 & o ? 1 : 2 & o ? 3 : 4 & o ? 2 : 0),
                        e
                    }
                },
                fix: function (e) {
                    if (e[Z.expando]) return e;
                    var t, n, i, r = e.type,
                    o = e,
                    a = this.fixHooks[r];
                    for (a || (this.fixHooks[r] = a = je.test(r) ? this.mouseHooks : _e.test(r) ? this.keyHooks : {}), i = a.props ? this.props.concat(a.props) : this.props, e = new Z.Event(o), t = i.length; t--;) n = i[t],
                    e[n] = o[n];
                    return e.target || (e.target = Y),
                    3 === e.target.nodeType && (e.target = e.target.parentNode),
                    a.filter ? a.filter(e, o) : e
                },
                special: {
                    load: {
                        noBubble: !0
                    },
                    focus: {
                        trigger: function () {
                            return this !== f() && this.focus ? (this.focus(), !1) : void 0
                        },
                        delegateType: "focusin"
                    },
                    blur: {
                        trigger: function () {
                            return this === f() && this.blur ? (this.blur(), !1) : void 0
                        },
                        delegateType: "focusout"
                    },
                    click: {
                        trigger: function () {
                            return "checkbox" === this.type && this.click && Z.nodeName(this, "input") ? (this.click(), !1) : void 0
                        },
                        _default: function (e) {
                            return Z.nodeName(e.target, "a")
                        }
                    },
                    beforeunload: {
                        postDispatch: function (e) {
                            void 0 !== e.result && e.originalEvent && (e.originalEvent.returnValue = e.result)
                        }
                    }
                },
                simulate: function (e, t, n, i) {
                    var r = Z.extend(new Z.Event, n, {
                        type: e,
                        isSimulated: !0,
                        originalEvent: {}
                    });
                    i ? Z.event.trigger(r, null, t) : Z.event.dispatch.call(t, r),
                    r.isDefaultPrevented() && n.preventDefault()
                }
            },
            Z.removeEvent = function (e, t, n) {
                e.removeEventListener && e.removeEventListener(t, n, !1)
            },
            Z.Event = function (e, t) {
                return this instanceof Z.Event ? (e && e.type ? (this.originalEvent = e, this.type = e.type, this.isDefaultPrevented = e.defaultPrevented || void 0 === e.defaultPrevented && e.returnValue === !1 ? c : l) : this.type = e, t && Z.extend(this, t), this.timeStamp = e && e.timeStamp || Z.now(), void (this[Z.expando] = !0)) : new Z.Event(e, t)
            },
            Z.Event.prototype = {
                isDefaultPrevented: l,
                isPropagationStopped: l,
                isImmediatePropagationStopped: l,
                preventDefault: function () {
                    var e = this.originalEvent;
                    this.isDefaultPrevented = c,
                    e && e.preventDefault && e.preventDefault()
                },
                stopPropagation: function () {
                    var e = this.originalEvent;
                    this.isPropagationStopped = c,
                    e && e.stopPropagation && e.stopPropagation()
                },
                stopImmediatePropagation: function () {
                    var e = this.originalEvent;
                    this.isImmediatePropagationStopped = c,
                    e && e.stopImmediatePropagation && e.stopImmediatePropagation(),
                    this.stopPropagation()
                }
            },
            Z.each({
                mouseenter: "mouseover",
                mouseleave: "mouseout",
                pointerenter: "pointerover",
                pointerleave: "pointerout"
            },
            function (e, t) {
                Z.event.special[e] = {
                    delegateType: t,
                    bindType: t,
                    handle: function (e) {
                        var n, i = this,
                        r = e.relatedTarget,
                        o = e.handleObj;
                        return (!r || r !== i && !Z.contains(i, r)) && (e.type = o.origType, n = o.handler.apply(this, arguments), e.type = t),
                        n
                    }
                }
            }),
            Q.focusinBubbles || Z.each({
                focus: "focusin",
                blur: "focusout"
            },
            function (e, t) {
                var n = function (e) {
                    Z.event.simulate(t, e.target, Z.event.fix(e), !0)
                };
                Z.event.special[t] = {
                    setup: function () {
                        var i = this.ownerDocument || this,
                        r = ve.access(i, t);
                        r || i.addEventListener(e, n, !0),
                        ve.access(i, t, (r || 0) + 1)
                    },
                    teardown: function () {
                        var i = this.ownerDocument || this,
                        r = ve.access(i, t) - 1;
                        r ? ve.access(i, t, r) : (i.removeEventListener(e, n, !0), ve.remove(i, t))
                    }
                }
            }),
            Z.fn.extend({
                on: function (e, t, n, i, r) {
                    var o, a;
                    if ("object" == typeof e) {
                        "string" != typeof t && (n = n || t, t = void 0);
                        for (a in e) this.on(a, t, n, e[a], r);
                        return this
                    }
                    if (null == n && null == i ? (i = t, n = t = void 0) : null == i && ("string" == typeof t ? (i = n, n = void 0) : (i = n, n = t, t = void 0)), i === !1) i = l;
                    else if (!i) return this;
                    return 1 === r && (o = i, i = function (e) {
                        return Z().off(e),
                        o.apply(this, arguments)
                    },
                    i.guid = o.guid || (o.guid = Z.guid++)),
                    this.each(function () {
                        Z.event.add(this, e, i, n, t)
                    })
                },
                one: function (e, t, n, i) {
                    return this.on(e, t, n, i, 1)
                },
                off: function (e, t, n) {
                    var i, r;
                    if (e && e.preventDefault && e.handleObj) return i = e.handleObj,
                    Z(e.delegateTarget).off(i.namespace ? i.origType + "." + i.namespace : i.origType, i.selector, i.handler),
                    this;
                    if ("object" == typeof e) {
                        for (r in e) this.off(r, t, e[r]);
                        return this
                    }
                    return (t === !1 || "function" == typeof t) && (n = t, t = void 0),
                    n === !1 && (n = l),
                    this.each(function () {
                        Z.event.remove(this, e, n, t)
                    })
                },
                trigger: function (e, t) {
                    return this.each(function () {
                        Z.event.trigger(e, t, this)
                    })
                },
                triggerHandler: function (e, t) {
                    var n = this[0];
                    return n ? Z.event.trigger(e, t, n, !0) : void 0
                }
            });
            var Ae = /<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/gi,
            Oe = /<([\w:]+)/,
            De = /<|&#?\w+;/,
            Ie = /<(?:script|style|link)/i,
            qe = /checked\s*(?:[^=]|=\s*.checked.)/i,
            Le = /^$|\/(?:java|ecma)script/i,
            Me = /^true\/(.*)/,
            $e = /^\s*<!(?:\[CDATA\[|--)|(?:\]\]|--)>\s*$/g,
            Pe = {
                option: [1, "<select multiple='multiple'>", "</select>"],
                thead: [1, "<table>", "</table>"],
                col: [2, "<table><colgroup>", "</colgroup></table>"],
                tr: [2, "<table><tbody>", "</tbody></table>"],
                td: [3, "<table><tbody><tr>", "</tr></tbody></table>"],
                _default: [0, "", ""]
            };
            Pe.optgroup = Pe.option,
            Pe.tbody = Pe.tfoot = Pe.colgroup = Pe.caption = Pe.thead,
            Pe.th = Pe.td,
            Z.extend({
                clone: function (e, t, n) {
                    var i, r, o, a, s = e.cloneNode(!0),
                    u = Z.contains(e.ownerDocument, e);
                    if (!(Q.noCloneChecked || 1 !== e.nodeType && 11 !== e.nodeType || Z.isXMLDoc(e))) for (a = v(s), o = v(e), i = 0, r = o.length; r > i; i++) y(o[i], a[i]);
                    if (t) if (n) for (o = o || v(e), a = a || v(s), i = 0, r = o.length; r > i; i++) m(o[i], a[i]);
                    else m(e, s);
                    return a = v(s, "script"),
                    a.length > 0 && g(a, !u && v(e, "script")),
                    s
                },
                buildFragment: function (e, t, n, i) {
                    for (var r, o, a, s, u, c, l = t.createDocumentFragment(), f = [], d = 0, p = e.length; p > d; d++) if (r = e[d], r || 0 === r) if ("object" === Z.type(r)) Z.merge(f, r.nodeType ? [r] : r);
                    else if (De.test(r)) {
                        for (o = o || l.appendChild(t.createElement("div")), a = (Oe.exec(r) || ["", ""])[1].toLowerCase(), s = Pe[a] || Pe._default, o.innerHTML = s[1] + r.replace(Ae, "<$1></$2>") + s[2], c = s[0]; c--;) o = o.lastChild;
                        Z.merge(f, o.childNodes),
                        o = l.firstChild,
                        o.textContent = ""
                    } else f.push(t.createTextNode(r));
                    for (l.textContent = "", d = 0; r = f[d++];) if ((!i || -1 === Z.inArray(r, i)) && (u = Z.contains(r.ownerDocument, r), o = v(l.appendChild(r), "script"), u && g(o), n)) for (c = 0; r = o[c++];) Le.test(r.type || "") && n.push(r);
                    return l
                },
                cleanData: function (e) {
                    for (var t, n, i, r, o = Z.event.special,
                    a = 0; void 0 !== (n = e[a]) ; a++) {
                        if (Z.acceptData(n) && (r = n[ve.expando], r && (t = ve.cache[r]))) {
                            if (t.events) for (i in t.events) o[i] ? Z.event.remove(n, i) : Z.removeEvent(n, i, t.handle);
                            ve.cache[r] && delete ve.cache[r]
                        }
                        delete ye.cache[n[ye.expando]]
                    }
                }
            }),
            Z.fn.extend({
                text: function (e) {
                    return me(this,
                    function (e) {
                        return void 0 === e ? Z.text(this) : this.empty().each(function () {
                            (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) && (this.textContent = e)
                        })
                    },
                    null, e, arguments.length)
                },
                append: function () {
                    return this.domManip(arguments,
                    function (e) {
                        if (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) {
                            var t = d(this, e);
                            t.appendChild(e)
                        }
                    })
                },
                prepend: function () {
                    return this.domManip(arguments,
                    function (e) {
                        if (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) {
                            var t = d(this, e);
                            t.insertBefore(e, t.firstChild)
                        }
                    })
                },
                before: function () {
                    return this.domManip(arguments,
                    function (e) {
                        this.parentNode && this.parentNode.insertBefore(e, this)
                    })
                },
                after: function () {
                    return this.domManip(arguments,
                    function (e) {
                        this.parentNode && this.parentNode.insertBefore(e, this.nextSibling)
                    })
                },
                remove: function (e, t) {
                    for (var n, i = e ? Z.filter(e, this) : this, r = 0; null != (n = i[r]) ; r++) t || 1 !== n.nodeType || Z.cleanData(v(n)),
                    n.parentNode && (t && Z.contains(n.ownerDocument, n) && g(v(n, "script")), n.parentNode.removeChild(n));
                    return this
                },
                empty: function () {
                    for (var e, t = 0; null != (e = this[t]) ; t++) 1 === e.nodeType && (Z.cleanData(v(e, !1)), e.textContent = "");
                    return this
                },
                clone: function (e, t) {
                    return e = null == e ? !1 : e,
                    t = null == t ? e : t,
                    this.map(function () {
                        return Z.clone(this, e, t)
                    })
                },
                html: function (e) {
                    return me(this,
                    function (e) {
                        var t = this[0] || {},
                        n = 0,
                        i = this.length;
                        if (void 0 === e && 1 === t.nodeType) return t.innerHTML;
                        if ("string" == typeof e && !Ie.test(e) && !Pe[(Oe.exec(e) || ["", ""])[1].toLowerCase()]) {
                            e = e.replace(Ae, "<$1></$2>");
                            try {
                                for (; i > n; n++) t = this[n] || {},
                                1 === t.nodeType && (Z.cleanData(v(t, !1)), t.innerHTML = e);
                                t = 0
                            } catch (r) { }
                        }
                        t && this.empty().append(e)
                    },
                    null, e, arguments.length)
                },
                replaceWith: function () {
                    var e = arguments[0];
                    return this.domManip(arguments,
                    function (t) {
                        e = this.parentNode,
                        Z.cleanData(v(this)),
                        e && e.replaceChild(t, this)
                    }),
                    e && (e.length || e.nodeType) ? this : this.remove()
                },
                detach: function (e) {
                    return this.remove(e, !0)
                },
                domManip: function (e, t) {
                    e = V.apply([], e);
                    var n, i, r, o, a, s, u = 0,
                    c = this.length,
                    l = this,
                    f = c - 1,
                    d = e[0],
                    g = Z.isFunction(d);
                    if (g || c > 1 && "string" == typeof d && !Q.checkClone && qe.test(d)) return this.each(function (n) {
                        var i = l.eq(n);
                        g && (e[0] = d.call(this, n, i.html())),
                        i.domManip(e, t)
                    });
                    if (c && (n = Z.buildFragment(e, this[0].ownerDocument, !1, this), i = n.firstChild, 1 === n.childNodes.length && (n = i), i)) {
                        for (r = Z.map(v(n, "script"), p), o = r.length; c > u; u++) a = n,
                        u !== f && (a = Z.clone(a, !0, !0), o && Z.merge(r, v(a, "script"))),
                        t.call(this[u], a, u);
                        if (o) for (s = r[r.length - 1].ownerDocument, Z.map(r, h), u = 0; o > u; u++) a = r[u],
                        Le.test(a.type || "") && !ve.access(a, "globalEval") && Z.contains(s, a) && (a.src ? Z._evalUrl && Z._evalUrl(a.src) : Z.globalEval(a.textContent.replace($e, "")))
                    }
                    return this
                }
            }),
            Z.each({
                appendTo: "append",
                prependTo: "prepend",
                insertBefore: "before",
                insertAfter: "after",
                replaceAll: "replaceWith"
            },
            function (e, t) {
                Z.fn[e] = function (e) {
                    for (var n, i = [], r = Z(e), o = r.length - 1, a = 0; o >= a; a++) n = a === o ? this : this.clone(!0),
                    Z(r[a])[t](n),
                    z.apply(i, n.get());
                    return this.pushStack(i)
                }
            });
            var Re, He = {},
            Fe = /^margin/,
            Be = new RegExp("^(" + be + ")(?!px)[a-z%]+$", "i"),
            We = function (t) {
                return t.ownerDocument.defaultView.opener ? t.ownerDocument.defaultView.getComputedStyle(t, null) : e.getComputedStyle(t, null)
            }; !
            function () {
                function t() {
                    a.style.cssText = "-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box;display:block;margin-top:1%;top:1%;border:1px;padding:1px;width:4px;position:absolute",
                    a.innerHTML = "",
                    r.appendChild(o);
                    var t = e.getComputedStyle(a, null);
                    n = "1%" !== t.top,
                    i = "4px" === t.width,
                    r.removeChild(o)
                }
                var n, i, r = Y.documentElement,
                o = Y.createElement("div"),
                a = Y.createElement("div");
                a.style && (a.style.backgroundClip = "content-box", a.cloneNode(!0).style.backgroundClip = "", Q.clearCloneStyle = "content-box" === a.style.backgroundClip, o.style.cssText = "border:0;width:0;height:0;top:0;left:-9999px;margin-top:1px;position:absolute", o.appendChild(a), e.getComputedStyle && Z.extend(Q, {
                    pixelPosition: function () {
                        return t(),
                        n
                    },
                    boxSizingReliable: function () {
                        return null == i && t(),
                        i
                    },
                    reliableMarginRight: function () {
                        var t, n = a.appendChild(Y.createElement("div"));
                        return n.style.cssText = a.style.cssText = "-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box;display:block;margin:0;border:0;padding:0",
                        n.style.marginRight = n.style.width = "0",
                        a.style.width = "1px",
                        r.appendChild(o),
                        t = !parseFloat(e.getComputedStyle(n, null).marginRight),
                        r.removeChild(o),
                        a.removeChild(n),
                        t
                    }
                }))
            }(),
            Z.swap = function (e, t, n, i) {
                var r, o, a = {};
                for (o in t) a[o] = e.style[o],
                e.style[o] = t[o];
                r = n.apply(e, i || []);
                for (o in t) e.style[o] = a[o];
                return r
            };
            var Ve = /^(none|table(?!-c[ea]).+)/,
            ze = new RegExp("^(" + be + ")(.*)$", "i"),
            Ue = new RegExp("^([+-])=(" + be + ")", "i"),
            Je = {
                position: "absolute",
                visibility: "hidden",
                display: "block"
            },
            Xe = {
                letterSpacing: "0",
                fontWeight: "400"
            },
            Ge = ["Webkit", "O", "Moz", "ms"];
            Z.extend({
                cssHooks: {
                    opacity: {
                        get: function (e, t) {
                            if (t) {
                                var n = b(e, "opacity");
                                return "" === n ? "1" : n
                            }
                        }
                    }
                },
                cssNumber: {
                    columnCount: !0,
                    fillOpacity: !0,
                    flexGrow: !0,
                    flexShrink: !0,
                    fontWeight: !0,
                    lineHeight: !0,
                    opacity: !0,
                    order: !0,
                    orphans: !0,
                    widows: !0,
                    zIndex: !0,
                    zoom: !0
                },
                cssProps: {
                    "float": "cssFloat"
                },
                style: function (e, t, n, i) {
                    if (e && 3 !== e.nodeType && 8 !== e.nodeType && e.style) {
                        var r, o, a, s = Z.camelCase(t),
                        u = e.style;
                        return t = Z.cssProps[s] || (Z.cssProps[s] = T(u, s)),
                        a = Z.cssHooks[t] || Z.cssHooks[s],
                        void 0 === n ? a && "get" in a && void 0 !== (r = a.get(e, !1, i)) ? r : u[t] : (o = typeof n, "string" === o && (r = Ue.exec(n)) && (n = (r[1] + 1) * r[2] + parseFloat(Z.css(e, t)), o = "number"), void (null != n && n === n && ("number" !== o || Z.cssNumber[s] || (n += "px"), Q.clearCloneStyle || "" !== n || 0 !== t.indexOf("background") || (u[t] = "inherit"), a && "set" in a && void 0 === (n = a.set(e, n, i)) || (u[t] = n))))
                    }
                },
                css: function (e, t, n, i) {
                    var r, o, a, s = Z.camelCase(t);
                    return t = Z.cssProps[s] || (Z.cssProps[s] = T(e.style, s)),
                    a = Z.cssHooks[t] || Z.cssHooks[s],
                    a && "get" in a && (r = a.get(e, !0, n)),
                    void 0 === r && (r = b(e, t, i)),
                    "normal" === r && t in Xe && (r = Xe[t]),
                    "" === n || n ? (o = parseFloat(r), n === !0 || Z.isNumeric(o) ? o || 0 : r) : r
                }
            }),
            Z.each(["height", "width"],
            function (e, t) {
                Z.cssHooks[t] = {
                    get: function (e, n, i) {
                        return n ? Ve.test(Z.css(e, "display")) && 0 === e.offsetWidth ? Z.swap(e, Je,
                        function () {
                            return _(e, t, i)
                        }) : _(e, t, i) : void 0
                    },
                    set: function (e, n, i) {
                        var r = i && We(e);
                        return S(e, n, i ? C(e, t, i, "border-box" === Z.css(e, "boxSizing", !1, r), r) : 0)
                    }
                }
            }),
            Z.cssHooks.marginRight = k(Q.reliableMarginRight,
            function (e, t) {
                return t ? Z.swap(e, {
                    display: "inline-block"
                },
                b, [e, "marginRight"]) : void 0
            }),
            Z.each({
                margin: "",
                padding: "",
                border: "Width"
            },
            function (e, t) {
                Z.cssHooks[e + t] = {
                    expand: function (n) {
                        for (var i = 0,
                        r = {},
                        o = "string" == typeof n ? n.split(" ") : [n]; 4 > i; i++) r[e + ke[i] + t] = o[i] || o[i - 2] || o[0];
                        return r
                    }
                },
                Fe.test(e) || (Z.cssHooks[e + t].set = S)
            }),
            Z.fn.extend({
                css: function (e, t) {
                    return me(this,
                    function (e, t, n) {
                        var i, r, o = {},
                        a = 0;
                        if (Z.isArray(t)) {
                            for (i = We(e), r = t.length; r > a; a++) o[t[a]] = Z.css(e, t[a], !1, i);
                            return o
                        }
                        return void 0 !== n ? Z.style(e, t, n) : Z.css(e, t)
                    },
                    e, t, arguments.length > 1)
                },
                show: function () {
                    return j(this, !0)
                },
                hide: function () {
                    return j(this)
                },
                toggle: function (e) {
                    return "boolean" == typeof e ? e ? this.show() : this.hide() : this.each(function () {
                        Te(this) ? Z(this).show() : Z(this).hide()
                    })
                }
            }),
            Z.Tween = E,
            E.prototype = {
                constructor: E,
                init: function (e, t, n, i, r, o) {
                    this.elem = e,
                    this.prop = n,
                    this.easing = r || "swing",
                    this.options = t,
                    this.start = this.now = this.cur(),
                    this.end = i,
                    this.unit = o || (Z.cssNumber[n] ? "" : "px")
                },
                cur: function () {
                    var e = E.propHooks[this.prop];
                    return e && e.get ? e.get(this) : E.propHooks._default.get(this)
                },
                run: function (e) {
                    var t, n = E.propHooks[this.prop];
                    return this.options.duration ? this.pos = t = Z.easing[this.easing](e, this.options.duration * e, 0, 1, this.options.duration) : this.pos = t = e,
                    this.now = (this.end - this.start) * t + this.start,
                    this.options.step && this.options.step.call(this.elem, this.now, this),
                    n && n.set ? n.set(this) : E.propHooks._default.set(this),
                    this
                }
            },
            E.prototype.init.prototype = E.prototype,
            E.propHooks = {
                _default: {
                    get: function (e) {
                        var t;
                        return null == e.elem[e.prop] || e.elem.style && null != e.elem.style[e.prop] ? (t = Z.css(e.elem, e.prop, ""), t && "auto" !== t ? t : 0) : e.elem[e.prop]
                    },
                    set: function (e) {
                        Z.fx.step[e.prop] ? Z.fx.step[e.prop](e) : e.elem.style && (null != e.elem.style[Z.cssProps[e.prop]] || Z.cssHooks[e.prop]) ? Z.style(e.elem, e.prop, e.now + e.unit) : e.elem[e.prop] = e.now
                    }
                }
            },
            E.propHooks.scrollTop = E.propHooks.scrollLeft = {
                set: function (e) {
                    e.elem.nodeType && e.elem.parentNode && (e.elem[e.prop] = e.now)
                }
            },
            Z.easing = {
                linear: function (e) {
                    return e
                },
                swing: function (e) {
                    return .5 - Math.cos(e * Math.PI) / 2
                }
            },
            Z.fx = E.prototype.init,
            Z.fx.step = {};
            var Qe, Ye, Ke = /^(?:toggle|show|hide)$/,
            Ze = new RegExp("^(?:([+-])=|)(" + be + ")([a-z%]*)$", "i"),
            et = /queueHooks$/,
            tt = [D],
            nt = {
                "*": [function (e, t) {
                    var n = this.createTween(e, t),
                    i = n.cur(),
                    r = Ze.exec(t),
                    o = r && r[3] || (Z.cssNumber[e] ? "" : "px"),
                    a = (Z.cssNumber[e] || "px" !== o && +i) && Ze.exec(Z.css(n.elem, e)),
                    s = 1,
                    u = 20;
                    if (a && a[3] !== o) {
                        o = o || a[3],
                        r = r || [],
                        a = +i || 1;
                        do s = s || ".5",
                        a /= s,
                        Z.style(n.elem, e, a + o);
                        while (s !== (s = n.cur() / i) && 1 !== s && --u)
                    }
                    return r && (a = n.start = +a || +i || 0, n.unit = o, n.end = r[1] ? a + (r[1] + 1) * r[2] : +r[2]),
                    n
                }]
            };
            Z.Animation = Z.extend(q, {
                tweener: function (e, t) {
                    Z.isFunction(e) ? (t = e, e = ["*"]) : e = e.split(" ");
                    for (var n, i = 0,
                    r = e.length; r > i; i++) n = e[i],
                    nt[n] = nt[n] || [],
                    nt[n].unshift(t)
                },
                prefilter: function (e, t) {
                    t ? tt.unshift(e) : tt.push(e)
                }
            }),
            Z.speed = function (e, t, n) {
                var i = e && "object" == typeof e ? Z.extend({},
                e) : {
                    complete: n || !n && t || Z.isFunction(e) && e,
                    duration: e,
                    easing: n && t || t && !Z.isFunction(t) && t
                };
                return i.duration = Z.fx.off ? 0 : "number" == typeof i.duration ? i.duration : i.duration in Z.fx.speeds ? Z.fx.speeds[i.duration] : Z.fx.speeds._default,
                (null == i.queue || i.queue === !0) && (i.queue = "fx"),
                i.old = i.complete,
                i.complete = function () {
                    Z.isFunction(i.old) && i.old.call(this),
                    i.queue && Z.dequeue(this, i.queue)
                },
                i
            },
            Z.fn.extend({
                fadeTo: function (e, t, n, i) {
                    return this.filter(Te).css("opacity", 0).show().end().animate({
                        opacity: t
                    },
                    e, n, i)
                },
                animate: function (e, t, n, i) {
                    var r = Z.isEmptyObject(e),
                    o = Z.speed(t, n, i),
                    a = function () {
                        var t = q(this, Z.extend({},
                        e), o); (r || ve.get(this, "finish")) && t.stop(!0)
                    };
                    return a.finish = a,
                    r || o.queue === !1 ? this.each(a) : this.queue(o.queue, a)
                },
                stop: function (e, t, n) {
                    var i = function (e) {
                        var t = e.stop;
                        delete e.stop,
                        t(n)
                    };
                    return "string" != typeof e && (n = t, t = e, e = void 0),
                    t && e !== !1 && this.queue(e || "fx", []),
                    this.each(function () {
                        var t = !0,
                        r = null != e && e + "queueHooks",
                        o = Z.timers,
                        a = ve.get(this);
                        if (r) a[r] && a[r].stop && i(a[r]);
                        else for (r in a) a[r] && a[r].stop && et.test(r) && i(a[r]);
                        for (r = o.length; r--;) o[r].elem !== this || null != e && o[r].queue !== e || (o[r].anim.stop(n), t = !1, o.splice(r, 1)); (t || !n) && Z.dequeue(this, e)
                    })
                },
                finish: function (e) {
                    return e !== !1 && (e = e || "fx"),
                    this.each(function () {
                        var t, n = ve.get(this),
                        i = n[e + "queue"],
                        r = n[e + "queueHooks"],
                        o = Z.timers,
                        a = i ? i.length : 0;
                        for (n.finish = !0, Z.queue(this, e, []), r && r.stop && r.stop.call(this, !0), t = o.length; t--;) o[t].elem === this && o[t].queue === e && (o[t].anim.stop(!0), o.splice(t, 1));
                        for (t = 0; a > t; t++) i[t] && i[t].finish && i[t].finish.call(this);
                        delete n.finish
                    })
                }
            }),
            Z.each(["toggle", "show", "hide"],
            function (e, t) {
                var n = Z.fn[t];
                Z.fn[t] = function (e, i, r) {
                    return null == e || "boolean" == typeof e ? n.apply(this, arguments) : this.animate(A(t, !0), e, i, r)
                }
            }),
            Z.each({
                slideDown: A("show"),
                slideUp: A("hide"),
                slideToggle: A("toggle"),
                fadeIn: {
                    opacity: "show"
                },
                fadeOut: {
                    opacity: "hide"
                },
                fadeToggle: {
                    opacity: "toggle"
                }
            },
            function (e, t) {
                Z.fn[e] = function (e, n, i) {
                    return this.animate(t, e, n, i)
                }
            }),
            Z.timers = [],
            Z.fx.tick = function () {
                var e, t = 0,
                n = Z.timers;
                for (Qe = Z.now() ; t < n.length; t++) e = n[t],
                e() || n[t] !== e || n.splice(t--, 1);
                n.length || Z.fx.stop(),
                Qe = void 0
            },
            Z.fx.timer = function (e) {
                Z.timers.push(e),
                e() ? Z.fx.start() : Z.timers.pop()
            },
            Z.fx.interval = 13,
            Z.fx.start = function () {
                Ye || (Ye = setInterval(Z.fx.tick, Z.fx.interval))
            },
            Z.fx.stop = function () {
                clearInterval(Ye),
                Ye = null
            },
            Z.fx.speeds = {
                slow: 600,
                fast: 200,
                _default: 400
            },
            Z.fn.delay = function (e, t) {
                return e = Z.fx ? Z.fx.speeds[e] || e : e,
                t = t || "fx",
                this.queue(t,
                function (t, n) {
                    var i = setTimeout(t, e);
                    n.stop = function () {
                        clearTimeout(i)
                    }
                })
            },
            function () {
                var e = Y.createElement("input"),
                t = Y.createElement("select"),
                n = t.appendChild(Y.createElement("option"));
                e.type = "checkbox",
                Q.checkOn = "" !== e.value,
                Q.optSelected = n.selected,
                t.disabled = !0,
                Q.optDisabled = !n.disabled,
                e = Y.createElement("input"),
                e.value = "t",
                e.type = "radio",
                Q.radioValue = "t" === e.value
            }();
            var it, rt, ot = Z.expr.attrHandle;
            Z.fn.extend({
                attr: function (e, t) {
                    return me(this, Z.attr, e, t, arguments.length > 1)
                },
                removeAttr: function (e) {
                    return this.each(function () {
                        Z.removeAttr(this, e)
                    })
                }
            }),
            Z.extend({
                attr: function (e, t, n) {
                    var i, r, o = e.nodeType;
                    return e && 3 !== o && 8 !== o && 2 !== o ? typeof e.getAttribute === Ce ? Z.prop(e, t, n) : (1 === o && Z.isXMLDoc(e) || (t = t.toLowerCase(), i = Z.attrHooks[t] || (Z.expr.match.bool.test(t) ? rt : it)), void 0 === n ? i && "get" in i && null !== (r = i.get(e, t)) ? r : (r = Z.find.attr(e, t), null == r ? void 0 : r) : null !== n ? i && "set" in i && void 0 !== (r = i.set(e, n, t)) ? r : (e.setAttribute(t, n + ""), n) : void Z.removeAttr(e, t)) : void 0
                },
                removeAttr: function (e, t) {
                    var n, i, r = 0,
                    o = t && t.match(pe);
                    if (o && 1 === e.nodeType) for (; n = o[r++];) i = Z.propFix[n] || n,
                    Z.expr.match.bool.test(n) && (e[i] = !1),
                    e.removeAttribute(n)
                },
                attrHooks: {
                    type: {
                        set: function (e, t) {
                            if (!Q.radioValue && "radio" === t && Z.nodeName(e, "input")) {
                                var n = e.value;
                                return e.setAttribute("type", t),
                                n && (e.value = n),
                                t
                            }
                        }
                    }
                }
            }),
            rt = {
                set: function (e, t, n) {
                    return t === !1 ? Z.removeAttr(e, n) : e.setAttribute(n, n),
                    n
                }
            },
            Z.each(Z.expr.match.bool.source.match(/\w+/g),
            function (e, t) {
                var n = ot[t] || Z.find.attr;
                ot[t] = function (e, t, i) {
                    var r, o;
                    return i || (o = ot[t], ot[t] = r, r = null != n(e, t, i) ? t.toLowerCase() : null, ot[t] = o),
                    r
                }
            });
            var at = /^(?:input|select|textarea|button)$/i;
            Z.fn.extend({
                prop: function (e, t) {
                    return me(this, Z.prop, e, t, arguments.length > 1)
                },
                removeProp: function (e) {
                    return this.each(function () {
                        delete this[Z.propFix[e] || e]
                    })
                }
            }),
            Z.extend({
                propFix: {
                    "for": "htmlFor",
                    "class": "className"
                },
                prop: function (e, t, n) {
                    var i, r, o, a = e.nodeType;
                    return e && 3 !== a && 8 !== a && 2 !== a ? (o = 1 !== a || !Z.isXMLDoc(e), o && (t = Z.propFix[t] || t, r = Z.propHooks[t]), void 0 !== n ? r && "set" in r && void 0 !== (i = r.set(e, n, t)) ? i : e[t] = n : r && "get" in r && null !== (i = r.get(e, t)) ? i : e[t]) : void 0
                },
                propHooks: {
                    tabIndex: {
                        get: function (e) {
                            return e.hasAttribute("tabindex") || at.test(e.nodeName) || e.href ? e.tabIndex : -1
                        }
                    }
                }
            }),
            Q.optSelected || (Z.propHooks.selected = {
                get: function (e) {
                    var t = e.parentNode;
                    return t && t.parentNode && t.parentNode.selectedIndex,
                    null
                }
            }),
            Z.each(["tabIndex", "readOnly", "maxLength", "cellSpacing", "cellPadding", "rowSpan", "colSpan", "useMap", "frameBorder", "contentEditable"],
            function () {
                Z.propFix[this.toLowerCase()] = this
            });
            var st = /[\t\r\n\f]/g;
            Z.fn.extend({
                addClass: function (e) {
                    var t, n, i, r, o, a, s = "string" == typeof e && e,
                    u = 0,
                    c = this.length;
                    if (Z.isFunction(e)) return this.each(function (t) {
                        Z(this).addClass(e.call(this, t, this.className))
                    });
                    if (s) for (t = (e || "").match(pe) || []; c > u; u++) if (n = this[u], i = 1 === n.nodeType && (n.className ? (" " + n.className + " ").replace(st, " ") : " ")) {
                        for (o = 0; r = t[o++];) i.indexOf(" " + r + " ") < 0 && (i += r + " ");
                        a = Z.trim(i),
                        n.className !== a && (n.className = a)
                    }
                    return this
                },
                removeClass: function (e) {
                    var t, n, i, r, o, a, s = 0 === arguments.length || "string" == typeof e && e,
                    u = 0,
                    c = this.length;
                    if (Z.isFunction(e)) return this.each(function (t) {
                        Z(this).removeClass(e.call(this, t, this.className))
                    });
                    if (s) for (t = (e || "").match(pe) || []; c > u; u++) if (n = this[u], i = 1 === n.nodeType && (n.className ? (" " + n.className + " ").replace(st, " ") : "")) {
                        for (o = 0; r = t[o++];) for (; i.indexOf(" " + r + " ") >= 0;) i = i.replace(" " + r + " ", " ");
                        a = e ? Z.trim(i) : "",
                        n.className !== a && (n.className = a)
                    }
                    return this
                },
                toggleClass: function (e, t) {
                    var n = typeof e;
                    return "boolean" == typeof t && "string" === n ? t ? this.addClass(e) : this.removeClass(e) : this.each(Z.isFunction(e) ?
                    function (n) {
                        Z(this).toggleClass(e.call(this, n, this.className, t), t)
                    } : function () {
                        if ("string" === n) for (var t, i = 0,
                        r = Z(this), o = e.match(pe) || []; t = o[i++];) r.hasClass(t) ? r.removeClass(t) : r.addClass(t);
                        else (n === Ce || "boolean" === n) && (this.className && ve.set(this, "__className__", this.className), this.className = this.className || e === !1 ? "" : ve.get(this, "__className__") || "")
                    })
                },
                hasClass: function (e) {
                    for (var t = " " + e + " ",
                    n = 0,
                    i = this.length; i > n; n++) if (1 === this[n].nodeType && (" " + this[n].className + " ").replace(st, " ").indexOf(t) >= 0) return !0;
                    return !1
                }
            });
            var ut = /\r/g;
            Z.fn.extend({
                val: function (e) {
                    var t, n, i, r = this[0];
                    return arguments.length ? (i = Z.isFunction(e), this.each(function (n) {
                        var r;
                        1 === this.nodeType && (r = i ? e.call(this, n, Z(this).val()) : e, null == r ? r = "" : "number" == typeof r ? r += "" : Z.isArray(r) && (r = Z.map(r,
                        function (e) {
                            return null == e ? "" : e + ""
                        })), t = Z.valHooks[this.type] || Z.valHooks[this.nodeName.toLowerCase()], t && "set" in t && void 0 !== t.set(this, r, "value") || (this.value = r))
                    })) : r ? (t = Z.valHooks[r.type] || Z.valHooks[r.nodeName.toLowerCase()], t && "get" in t && void 0 !== (n = t.get(r, "value")) ? n : (n = r.value, "string" == typeof n ? n.replace(ut, "") : null == n ? "" : n)) : void 0
                }
            }),
            Z.extend({
                valHooks: {
                    option: {
                        get: function (e) {
                            var t = Z.find.attr(e, "value");
                            return null != t ? t : Z.trim(Z.text(e))
                        }
                    },
                    select: {
                        get: function (e) {
                            for (var t, n, i = e.options,
                            r = e.selectedIndex,
                            o = "select-one" === e.type || 0 > r,
                            a = o ? null : [], s = o ? r + 1 : i.length, u = 0 > r ? s : o ? r : 0; s > u; u++) if (n = i[u], !(!n.selected && u !== r || (Q.optDisabled ? n.disabled : null !== n.getAttribute("disabled")) || n.parentNode.disabled && Z.nodeName(n.parentNode, "optgroup"))) {
                                if (t = Z(n).val(), o) return t;
                                a.push(t)
                            }
                            return a
                        },
                        set: function (e, t) {
                            for (var n, i, r = e.options,
                            o = Z.makeArray(t), a = r.length; a--;) i = r[a],
                            (i.selected = Z.inArray(i.value, o) >= 0) && (n = !0);
                            return n || (e.selectedIndex = -1),
                            o
                        }
                    }
                }
            }),
            Z.each(["radio", "checkbox"],
            function () {
                Z.valHooks[this] = {
                    set: function (e, t) {
                        return Z.isArray(t) ? e.checked = Z.inArray(Z(e).val(), t) >= 0 : void 0
                    }
                },
                Q.checkOn || (Z.valHooks[this].get = function (e) {
                    return null === e.getAttribute("value") ? "on" : e.value
                })
            }),
            Z.each("blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error contextmenu".split(" "),
            function (e, t) {
                Z.fn[t] = function (e, n) {
                    return arguments.length > 0 ? this.on(t, null, e, n) : this.trigger(t)
                }
            }),
            Z.fn.extend({
                hover: function (e, t) {
                    return this.mouseenter(e).mouseleave(t || e)
                },
                bind: function (e, t, n) {
                    return this.on(e, null, t, n)
                },
                unbind: function (e, t) {
                    return this.off(e, null, t)
                },
                delegate: function (e, t, n, i) {
                    return this.on(t, e, n, i)
                },
                undelegate: function (e, t, n) {
                    return 1 === arguments.length ? this.off(e, "**") : this.off(t, e || "**", n)
                }
            });
            var ct = Z.now(),
            lt = /\?/;
            Z.parseJSON = function (e) {
                return JSON.parse(e + "")
            },
            Z.parseXML = function (e) {
                var t, n;
                if (!e || "string" != typeof e) return null;
                try {
                    n = new DOMParser,
                    t = n.parseFromString(e, "text/xml")
                } catch (i) {
                    t = void 0
                }
                return (!t || t.getElementsByTagName("parsererror").length) && Z.error("Invalid XML: " + e),
                t
            };
            var ft = /#.*$/,
            dt = /([?&])_=[^&]*/,
            pt = /^(.*?):[ \t]*([^\r\n]*)$/gm,
            ht = /^(?:about|app|app-storage|.+-extension|file|res|widget):$/,
            gt = /^(?:GET|HEAD)$/,
            mt = /^\/\//,
            vt = /^([\w.+-]+:)(?:\/\/(?:[^\/?#]*@|)([^\/?#:]*)(?::(\d+)|)|)/,
            yt = {},
            xt = {},
            wt = "*/".concat("*"),
            bt = e.location.href,
            kt = vt.exec(bt.toLowerCase()) || [];
            Z.extend({
                active: 0,
                lastModified: {},
                etag: {},
                ajaxSettings: {
                    url: bt,
                    type: "GET",
                    isLocal: ht.test(kt[1]),
                    global: !0,
                    processData: !0,
                    async: !0,
                    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                    accepts: {
                        "*": wt,
                        text: "text/plain",
                        html: "text/html",
                        xml: "application/xml, text/xml",
                        json: "application/json, text/javascript"
                    },
                    contents: {
                        xml: /xml/,
                        html: /html/,
                        json: /json/
                    },
                    responseFields: {
                        xml: "responseXML",
                        text: "responseText",
                        json: "responseJSON"
                    },
                    converters: {
                        "* text": String,
                        "text html": !0,
                        "text json": Z.parseJSON,
                        "text xml": Z.parseXML
                    },
                    flatOptions: {
                        url: !0,
                        context: !0
                    }
                },
                ajaxSetup: function (e, t) {
                    return t ? $($(e, Z.ajaxSettings), t) : $(Z.ajaxSettings, e)
                },
                ajaxPrefilter: L(yt),
                ajaxTransport: L(xt),
                ajax: function (e, t) {
                    function n(e, t, n, a) {
                        var u, l, v, y, w, k = t;
                        2 !== x && (x = 2, s && clearTimeout(s), i = void 0, o = a || "", b.readyState = e > 0 ? 4 : 0, u = e >= 200 && 300 > e || 304 === e, n && (y = P(f, b, n)), y = R(f, y, b, u), u ? (f.ifModified && (w = b.getResponseHeader("Last-Modified"), w && (Z.lastModified[r] = w), w = b.getResponseHeader("etag"), w && (Z.etag[r] = w)), 204 === e || "HEAD" === f.type ? k = "nocontent" : 304 === e ? k = "notmodified" : (k = y.state, l = y.data, v = y.error, u = !v)) : (v = k, (e || !k) && (k = "error", 0 > e && (e = 0))), b.status = e, b.statusText = (t || k) + "", u ? h.resolveWith(d, [l, k, b]) : h.rejectWith(d, [b, k, v]), b.statusCode(m), m = void 0, c && p.trigger(u ? "ajaxSuccess" : "ajaxError", [b, f, u ? l : v]), g.fireWith(d, [b, k]), c && (p.trigger("ajaxComplete", [b, f]), --Z.active || Z.event.trigger("ajaxStop")))
                    }
                    "object" == typeof e && (t = e, e = void 0),
                    t = t || {};
                    var i, r, o, a, s, u, c, l, f = Z.ajaxSetup({},
                    t),
                    d = f.context || f,
                    p = f.context && (d.nodeType || d.jquery) ? Z(d) : Z.event,
                    h = Z.Deferred(),
                    g = Z.Callbacks("once memory"),
                    m = f.statusCode || {},
                    v = {},
                    y = {},
                    x = 0,
                    w = "canceled",
                    b = {
                        readyState: 0,
                        getResponseHeader: function (e) {
                            var t;
                            if (2 === x) {
                                if (!a) for (a = {}; t = pt.exec(o) ;) a[t[1].toLowerCase()] = t[2];
                                t = a[e.toLowerCase()]
                            }
                            return null == t ? null : t
                        },
                        getAllResponseHeaders: function () {
                            return 2 === x ? o : null
                        },
                        setRequestHeader: function (e, t) {
                            var n = e.toLowerCase();
                            return x || (e = y[n] = y[n] || e, v[e] = t),
                            this
                        },
                        overrideMimeType: function (e) {
                            return x || (f.mimeType = e),
                            this
                        },
                        statusCode: function (e) {
                            var t;
                            if (e) if (2 > x) for (t in e) m[t] = [m[t], e[t]];
                            else b.always(e[b.status]);
                            return this
                        },
                        abort: function (e) {
                            var t = e || w;
                            return i && i.abort(t),
                            n(0, t),
                            this
                        }
                    };
                    if (h.promise(b).complete = g.add, b.success = b.done, b.error = b.fail, f.url = ((e || f.url || bt) + "").replace(ft, "").replace(mt, kt[1] + "//"), f.type = t.method || t.type || f.method || f.type, f.dataTypes = Z.trim(f.dataType || "*").toLowerCase().match(pe) || [""], null == f.crossDomain && (u = vt.exec(f.url.toLowerCase()), f.crossDomain = !(!u || u[1] === kt[1] && u[2] === kt[2] && (u[3] || ("http:" === u[1] ? "80" : "443")) === (kt[3] || ("http:" === kt[1] ? "80" : "443")))), f.data && f.processData && "string" != typeof f.data && (f.data = Z.param(f.data, f.traditional)), M(yt, f, t, b), 2 === x) return b;
                    c = Z.event && f.global,
                    c && 0 === Z.active++ && Z.event.trigger("ajaxStart"),
                    f.type = f.type.toUpperCase(),
                    f.hasContent = !gt.test(f.type),
                    r = f.url,
                    f.hasContent || (f.data && (r = f.url += (lt.test(r) ? "&" : "?") + f.data, delete f.data), f.cache === !1 && (f.url = dt.test(r) ? r.replace(dt, "$1_=" + ct++) : r + (lt.test(r) ? "&" : "?") + "_=" + ct++)),
                    f.ifModified && (Z.lastModified[r] && b.setRequestHeader("If-Modified-Since", Z.lastModified[r]), Z.etag[r] && b.setRequestHeader("If-None-Match", Z.etag[r])),
                    (f.data && f.hasContent && f.contentType !== !1 || t.contentType) && b.setRequestHeader("Content-Type", f.contentType),
                    b.setRequestHeader("Accept", f.dataTypes[0] && f.accepts[f.dataTypes[0]] ? f.accepts[f.dataTypes[0]] + ("*" !== f.dataTypes[0] ? ", " + wt + "; q=0.01" : "") : f.accepts["*"]);
                    for (l in f.headers) b.setRequestHeader(l, f.headers[l]);
                    if (f.beforeSend && (f.beforeSend.call(d, b, f) === !1 || 2 === x)) return b.abort();
                    w = "abort";
                    for (l in {
                        success: 1,
                        error: 1,
                        complete: 1
                    }) b[l](f[l]);
                    if (i = M(xt, f, t, b)) {
                        b.readyState = 1,
                        c && p.trigger("ajaxSend", [b, f]),
                        f.async && f.timeout > 0 && (s = setTimeout(function () {
                            b.abort("timeout")
                        },
                        f.timeout));
                        try {
                            x = 1,
                            i.send(v, n)
                        } catch (k) {
                            if (!(2 > x)) throw k;
                            n(-1, k)
                        }
                    } else n(-1, "No Transport");
                    return b
                },
                getJSON: function (e, t, n) {
                    return Z.get(e, t, n, "json")
                },
                getScript: function (e, t) {
                    return Z.get(e, void 0, t, "script")
                }
            }),
            Z.each(["get", "post"],
            function (e, t) {
                Z[t] = function (e, n, i, r) {
                    return Z.isFunction(n) && (r = r || i, i = n, n = void 0),
                    Z.ajax({
                        url: e,
                        type: t,
                        dataType: r,
                        data: n,
                        success: i
                    })
                }
            }),
            Z._evalUrl = function (e) {
                return Z.ajax({
                    url: e,
                    type: "GET",
                    dataType: "script",
                    async: !1,
                    global: !1,
                    "throws": !0
                })
            },
            Z.fn.extend({
                wrapAll: function (e) {
                    var t;
                    return Z.isFunction(e) ? this.each(function (t) {
                        Z(this).wrapAll(e.call(this, t))
                    }) : (this[0] && (t = Z(e, this[0].ownerDocument).eq(0).clone(!0), this[0].parentNode && t.insertBefore(this[0]), t.map(function () {
                        for (var e = this; e.firstElementChild;) e = e.firstElementChild;
                        return e
                    }).append(this)), this)
                },
                wrapInner: function (e) {
                    return this.each(Z.isFunction(e) ?
                    function (t) {
                        Z(this).wrapInner(e.call(this, t))
                    } : function () {
                        var t = Z(this),
                        n = t.contents();
                        n.length ? n.wrapAll(e) : t.append(e)
                    })
                },
                wrap: function (e) {
                    var t = Z.isFunction(e);
                    return this.each(function (n) {
                        Z(this).wrapAll(t ? e.call(this, n) : e)
                    })
                },
                unwrap: function () {
                    return this.parent().each(function () {
                        Z.nodeName(this, "body") || Z(this).replaceWith(this.childNodes)
                    }).end()
                }
            }),
            Z.expr.filters.hidden = function (e) {
                return e.offsetWidth <= 0 && e.offsetHeight <= 0
            },
            Z.expr.filters.visible = function (e) {
                return !Z.expr.filters.hidden(e)
            };
            var Tt = /%20/g,
            St = /\[\]$/,
            Ct = /\r?\n/g,
            _t = /^(?:submit|button|image|reset|file)$/i,
            jt = /^(?:input|select|textarea|keygen)/i;
            Z.param = function (e, t) {
                var n, i = [],
                r = function (e, t) {
                    t = Z.isFunction(t) ? t() : null == t ? "" : t,
                    i[i.length] = encodeURIComponent(e) + "=" + encodeURIComponent(t)
                };
                if (void 0 === t && (t = Z.ajaxSettings && Z.ajaxSettings.traditional), Z.isArray(e) || e.jquery && !Z.isPlainObject(e)) Z.each(e,
                function () {
                    r(this.name, this.value)
                });
                else for (n in e) H(n, e[n], t, r);
                return i.join("&").replace(Tt, "+")
            },
            Z.fn.extend({
                serialize: function () {
                    return Z.param(this.serializeArray())
                },
                serializeArray: function () {
                    return this.map(function () {
                        var e = Z.prop(this, "elements");
                        return e ? Z.makeArray(e) : this
                    }).filter(function () {
                        var e = this.type;
                        return this.name && !Z(this).is(":disabled") && jt.test(this.nodeName) && !_t.test(e) && (this.checked || !Se.test(e))
                    }).map(function (e, t) {
                        var n = Z(this).val();
                        return null == n ? null : Z.isArray(n) ? Z.map(n,
                        function (e) {
                            return {
                                name: t.name,
                                value: e.replace(Ct, "\r\n")
                            }
                        }) : {
                            name: t.name,
                            value: n.replace(Ct, "\r\n")
                        }
                    }).get()
                }
            }),
            Z.ajaxSettings.xhr = function () {
                try {
                    return new XMLHttpRequest
                } catch (e) { }
            };
            var Et = 0,
            Nt = {},
            At = {
                0: 200,
                1223: 204
            },
            Ot = Z.ajaxSettings.xhr();
            e.attachEvent && e.attachEvent("onunload",
            function () {
                for (var e in Nt) Nt[e]()
            }),
            Q.cors = !!Ot && "withCredentials" in Ot,
            Q.ajax = Ot = !!Ot,
            Z.ajaxTransport(function (e) {
                var t;
                return Q.cors || Ot && !e.crossDomain ? {
                    send: function (n, i) {
                        var r, o = e.xhr(),
                        a = ++Et;
                        if (o.open(e.type, e.url, e.async, e.username, e.password), e.xhrFields) for (r in e.xhrFields) o[r] = e.xhrFields[r];
                        e.mimeType && o.overrideMimeType && o.overrideMimeType(e.mimeType),
                        e.crossDomain || n["X-Requested-With"] || (n["X-Requested-With"] = "XMLHttpRequest");
                        for (r in n) o.setRequestHeader(r, n[r]);
                        t = function (e) {
                            return function () {
                                t && (delete Nt[a], t = o.onload = o.onerror = null, "abort" === e ? o.abort() : "error" === e ? i(o.status, o.statusText) : i(At[o.status] || o.status, o.statusText, "string" == typeof o.responseText ? {
                                    text: o.responseText
                                } : void 0, o.getAllResponseHeaders()))
                            }
                        },
                        o.onload = t(),
                        o.onerror = t("error"),
                        t = Nt[a] = t("abort");
                        try {
                            o.send(e.hasContent && e.data || null)
                        } catch (s) {
                            if (t) throw s
                        }
                    },
                    abort: function () {
                        t && t()
                    }
                } : void 0
            }),
            Z.ajaxSetup({
                accepts: {
                    script: "text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"
                },
                contents: {
                    script: /(?:java|ecma)script/
                },
                converters: {
                    "text script": function (e) {
                        return Z.globalEval(e),
                        e
                    }
                }
            }),
            Z.ajaxPrefilter("script",
            function (e) {
                void 0 === e.cache && (e.cache = !1),
                e.crossDomain && (e.type = "GET")
            }),
            Z.ajaxTransport("script",
            function (e) {
                if (e.crossDomain) {
                    var t, n;
                    return {
                        send: function (i, r) {
                            t = Z("<script>").prop({
                                async: !0,
                                charset: e.scriptCharset,
                                src: e.url
                            }).on("load error", n = function (e) {
                                t.remove(),
                                n = null,
                                e && r("error" === e.type ? 404 : 200, e.type)
                            }),
                            Y.head.appendChild(t[0])
                        },
                        abort: function () {
                            n && n()
                        }
                    }
                }
            });
            var Dt = [],
            It = /(=)\?(?=&|$)|\?\?/;
            Z.ajaxSetup({
                jsonp: "callback",
                jsonpCallback: function () {
                    var e = Dt.pop() || Z.expando + "_" + ct++;
                    return this[e] = !0,
                    e
                }
            }),
            Z.ajaxPrefilter("json jsonp",
            function (t, n, i) {
                var r, o, a, s = t.jsonp !== !1 && (It.test(t.url) ? "url" : "string" == typeof t.data && !(t.contentType || "").indexOf("application/x-www-form-urlencoded") && It.test(t.data) && "data");
                return s || "jsonp" === t.dataTypes[0] ? (r = t.jsonpCallback = Z.isFunction(t.jsonpCallback) ? t.jsonpCallback() : t.jsonpCallback, s ? t[s] = t[s].replace(It, "$1" + r) : t.jsonp !== !1 && (t.url += (lt.test(t.url) ? "&" : "?") + t.jsonp + "=" + r), t.converters["script json"] = function () {
                    return a || Z.error(r + " was not called"),
                    a[0]
                },
                t.dataTypes[0] = "json", o = e[r], e[r] = function () {
                    a = arguments
                },
                i.always(function () {
                    e[r] = o,
                    t[r] && (t.jsonpCallback = n.jsonpCallback, Dt.push(r)),
                    a && Z.isFunction(o) && o(a[0]),
                    a = o = void 0
                }), "script") : void 0
            }),
            Z.parseHTML = function (e, t, n) {
                if (!e || "string" != typeof e) return null;
                "boolean" == typeof t && (n = t, t = !1),
                t = t || Y;
                var i = ae.exec(e),
                r = !n && [];
                return i ? [t.createElement(i[1])] : (i = Z.buildFragment([e], t, r), r && r.length && Z(r).remove(), Z.merge([], i.childNodes))
            };
            var qt = Z.fn.load;
            Z.fn.load = function (e, t, n) {
                if ("string" != typeof e && qt) return qt.apply(this, arguments);
                var i, r, o, a = this,
                s = e.indexOf(" ");
                return s >= 0 && (i = Z.trim(e.slice(s)), e = e.slice(0, s)),
                Z.isFunction(t) ? (n = t, t = void 0) : t && "object" == typeof t && (r = "POST"),
                a.length > 0 && Z.ajax({
                    url: e,
                    type: r,
                    dataType: "html",
                    data: t
                }).done(function (e) {
                    o = arguments,
                    a.html(i ? Z("<div>").append(Z.parseHTML(e)).find(i) : e)
                }).complete(n &&
                function (e, t) {
                    a.each(n, o || [e.responseText, t, e])
                }),
                this
            },
            Z.each(["ajaxStart", "ajaxStop", "ajaxComplete", "ajaxError", "ajaxSuccess", "ajaxSend"],
            function (e, t) {
                Z.fn[t] = function (e) {
                    return this.on(t, e)
                }
            }),
            Z.expr.filters.animated = function (e) {
                return Z.grep(Z.timers,
                function (t) {
                    return e === t.elem
                }).length
            };
            var Lt = e.document.documentElement;
            Z.offset = {
                setOffset: function (e, t, n) {
                    var i, r, o, a, s, u, c, l = Z.css(e, "position"),
                    f = Z(e),
                    d = {};
                    "static" === l && (e.style.position = "relative"),
                    s = f.offset(),
                    o = Z.css(e, "top"),
                    u = Z.css(e, "left"),
                    c = ("absolute" === l || "fixed" === l) && (o + u).indexOf("auto") > -1,
                    c ? (i = f.position(), a = i.top, r = i.left) : (a = parseFloat(o) || 0, r = parseFloat(u) || 0),
                    Z.isFunction(t) && (t = t.call(e, n, s)),
                    null != t.top && (d.top = t.top - s.top + a),
                    null != t.left && (d.left = t.left - s.left + r),
                    "using" in t ? t.using.call(e, d) : f.css(d)
                }
            },
            Z.fn.extend({
                offset: function (e) {
                    if (arguments.length) return void 0 === e ? this : this.each(function (t) {
                        Z.offset.setOffset(this, e, t)
                    });
                    var t, n, i = this[0],
                    r = {
                        top: 0,
                        left: 0
                    },
                    o = i && i.ownerDocument;
                    return o ? (t = o.documentElement, Z.contains(t, i) ? (typeof i.getBoundingClientRect !== Ce && (r = i.getBoundingClientRect()), n = F(o), {
                        top: r.top + n.pageYOffset - t.clientTop,
                        left: r.left + n.pageXOffset - t.clientLeft
                    }) : r) : void 0
                },
                position: function () {
                    if (this[0]) {
                        var e, t, n = this[0],
                        i = {
                            top: 0,
                            left: 0
                        };
                        return "fixed" === Z.css(n, "position") ? t = n.getBoundingClientRect() : (e = this.offsetParent(), t = this.offset(), Z.nodeName(e[0], "html") || (i = e.offset()), i.top += Z.css(e[0], "borderTopWidth", !0), i.left += Z.css(e[0], "borderLeftWidth", !0)),
                        {
                            top: t.top - i.top - Z.css(n, "marginTop", !0),
                            left: t.left - i.left - Z.css(n, "marginLeft", !0)
                        }
                    }
                },
                offsetParent: function () {
                    return this.map(function () {
                        for (var e = this.offsetParent || Lt; e && !Z.nodeName(e, "html") && "static" === Z.css(e, "position") ;) e = e.offsetParent;
                        return e || Lt
                    })
                }
            }),
            Z.each({
                scrollLeft: "pageXOffset",
                scrollTop: "pageYOffset"
            },
            function (t, n) {
                var i = "pageYOffset" === n;
                Z.fn[t] = function (r) {
                    return me(this,
                    function (t, r, o) {
                        var a = F(t);
                        return void 0 === o ? a ? a[n] : t[r] : void (a ? a.scrollTo(i ? e.pageXOffset : o, i ? o : e.pageYOffset) : t[r] = o)
                    },
                    t, r, arguments.length, null)
                }
            }),
            Z.each(["top", "left"],
            function (e, t) {
                Z.cssHooks[t] = k(Q.pixelPosition,
                function (e, n) {
                    return n ? (n = b(e, t), Be.test(n) ? Z(e).position()[t] + "px" : n) : void 0
                })
            }),
            Z.each({
                Height: "height",
                Width: "width"
            },
            function (e, t) {
                Z.each({
                    padding: "inner" + e,
                    content: t,
                    "": "outer" + e
                },
                function (n, i) {
                    Z.fn[i] = function (i, r) {
                        var o = arguments.length && (n || "boolean" != typeof i),
                        a = n || (i === !0 || r === !0 ? "margin" : "border");
                        return me(this,
                        function (t, n, i) {
                            var r;
                            return Z.isWindow(t) ? t.document.documentElement["client" + e] : 9 === t.nodeType ? (r = t.documentElement, Math.max(t.body["scroll" + e], r["scroll" + e], t.body["offset" + e], r["offset" + e], r["client" + e])) : void 0 === i ? Z.css(t, n, a) : Z.style(t, n, i, a)
                        },
                        t, o ? i : void 0, o, null)
                    }
                })
            }),
            Z.fn.size = function () {
                return this.length
            },
            Z.fn.andSelf = Z.fn.addBack,
            "function" == typeof define && define.amd && define("jquery", [],
            function () {
                return Z
            });
            var Mt = e.jQuery,
            $t = e.$;
            return Z.noConflict = function (t) {
                return e.$ === Z && (e.$ = $t),
                t && e.jQuery === Z && (e.jQuery = Mt),
                Z
            },
            typeof t === Ce && (e.jQuery = e.$ = Z),
            Z
        })
}.call(this),
function () {
    !
        function (e, t) {
            if ("function" == typeof define && define.amd) define("Backbone", ["underscore", "jquery", "exports", "jquery", "underscore"],
            function (n, i, r) {
                e.Backbone = t(e, r, n, i)
            });
            else if ("undefined" != typeof exports) {
                var n = require("underscore");
                t(e, exports, n)
            } else e.Backbone = t(e, {},
            e._, e.jQuery || e.Zepto || e.ender || e.$)
        }(this,
        function (e, t, n, i) {
            var r = e.Backbone,
            o = [],
            a = (o.push, o.slice);
            o.splice;
            t.VERSION = "1.1.2",
            t.$ = i,
            t.noConflict = function () {
                return e.Backbone = r,
                this
            },
            t.emulateHTTP = !1,
            t.emulateJSON = !1;
            var s = t.Events = {
                on: function (e, t, n) {
                    if (!c(this, "on", e, [t, n]) || !t) return this;
                    this._events || (this._events = {});
                    var i = this._events[e] || (this._events[e] = []);
                    return i.push({
                        callback: t,
                        context: n,
                        ctx: n || this
                    }),
                    this
                },
                once: function (e, t, i) {
                    if (!c(this, "once", e, [t, i]) || !t) return this;
                    var r = this,
                    o = n.once(function () {
                        r.off(e, o),
                        t.apply(this, arguments)
                    });
                    return o._callback = t,
                    this.on(e, o, i)
                },
                off: function (e, t, i) {
                    var r, o, a, s, u, l, f, d;
                    if (!this._events || !c(this, "off", e, [t, i])) return this;
                    if (!e && !t && !i) return this._events = void 0,
                    this;
                    for (s = e ? [e] : n.keys(this._events), u = 0, l = s.length; l > u; u++) if (e = s[u], a = this._events[e]) {
                        if (this._events[e] = r = [], t || i) for (f = 0, d = a.length; d > f; f++) o = a[f],
                        (t && t !== o.callback && t !== o.callback._callback || i && i !== o.context) && r.push(o);
                        r.length || delete this._events[e]
                    }
                    return this
                },
                trigger: function (e) {
                    if (!this._events) return this;
                    var t = a.call(arguments, 1);
                    if (!c(this, "trigger", e, t)) return this;
                    var n = this._events[e],
                    i = this._events.all;
                    return n && l(n, t),
                    i && l(i, arguments),
                    this
                },
                stopListening: function (e, t, i) {
                    var r = this._listeningTo;
                    if (!r) return this;
                    var o = !t && !i;
                    i || "object" != typeof t || (i = this),
                    e && ((r = {})[e._listenId] = e);
                    for (var a in r) e = r[a],
                    e.off(t, i, this),
                    (o || n.isEmpty(e._events)) && delete this._listeningTo[a];
                    return this
                }
            },
            u = /\s+/,
            c = function (e, t, n, i) {
                if (!n) return !0;
                if ("object" == typeof n) {
                    for (var r in n) e[t].apply(e, [r, n[r]].concat(i));
                    return !1
                }
                if (u.test(n)) {
                    for (var o = n.split(u), a = 0, s = o.length; s > a; a++) e[t].apply(e, [o[a]].concat(i));
                    return !1
                }
                return !0
            },
            l = function (e, t) {
                var n, i = -1,
                r = e.length,
                o = t[0],
                a = t[1],
                s = t[2];
                switch (t.length) {
                    case 0:
                        for (; ++i < r;) (n = e[i]).callback.call(n.ctx);
                        return;
                    case 1:
                        for (; ++i < r;) (n = e[i]).callback.call(n.ctx, o);
                        return;
                    case 2:
                        for (; ++i < r;) (n = e[i]).callback.call(n.ctx, o, a);
                        return;
                    case 3:
                        for (; ++i < r;) (n = e[i]).callback.call(n.ctx, o, a, s);
                        return;
                    default:
                        for (; ++i < r;) (n = e[i]).callback.apply(n.ctx, t);
                        return
                }
            },
            f = {
                listenTo: "on",
                listenToOnce: "once"
            };
            n.each(f,
            function (e, t) {
                s[t] = function (t, i, r) {
                    var o = this._listeningTo || (this._listeningTo = {}),
                    a = t._listenId || (t._listenId = n.uniqueId("l"));
                    return o[a] = t,
                    r || "object" != typeof i || (r = this),
                    t[e](i, r, this),
                    this
                }
            }),
            s.bind = s.on,
            s.unbind = s.off,
            n.extend(t, s);
            var d = t.Model = function (e, t) {
                var i = e || {};
                t || (t = {}),
                this.cid = n.uniqueId("c"),
                this.attributes = {},
                t.collection && (this.collection = t.collection),
                t.parse && (i = this.parse(i, t) || {}),
                i = n.defaults({},
                i, n.result(this, "defaults")),
                this.set(i, t),
                this.changed = {},
                this.initialize.apply(this, arguments)
            };
            n.extend(d.prototype, s, {
                changed: null,
                validationError: null,
                idAttribute: "id",
                initialize: function () { },
                toJSON: function (e) {
                    return n.clone(this.attributes)
                },
                sync: function () {
                    return t.sync.apply(this, arguments)
                },
                get: function (e) {
                    return this.attributes[e]
                },
                escape: function (e) {
                    return n.escape(this.get(e))
                },
                has: function (e) {
                    return null != this.get(e)
                },
                set: function (e, t, i) {
                    var r, o, a, s, u, c, l, f;
                    if (null == e) return this;
                    if ("object" == typeof e ? (o = e, i = t) : (o = {})[e] = t, i || (i = {}), !this._validate(o, i)) return !1;
                    a = i.unset,
                    u = i.silent,
                    s = [],
                    c = this._changing,
                    this._changing = !0,
                    c || (this._previousAttributes = n.clone(this.attributes), this.changed = {}),
                    f = this.attributes,
                    l = this._previousAttributes,
                    this.idAttribute in o && (this.id = o[this.idAttribute]);
                    for (r in o) t = o[r],
                    n.isEqual(f[r], t) || s.push(r),
                    n.isEqual(l[r], t) ? delete this.changed[r] : this.changed[r] = t,
                    a ? delete f[r] : f[r] = t;
                    if (!u) {
                        s.length && (this._pending = i);
                        for (var d = 0,
                        p = s.length; p > d; d++) this.trigger("change:" + s[d], this, f[s[d]], i)
                    }
                    if (c) return this;
                    if (!u) for (; this._pending;) i = this._pending,
                    this._pending = !1,
                    this.trigger("change", this, i);
                    return this._pending = !1,
                    this._changing = !1,
                    this
                },
                unset: function (e, t) {
                    return this.set(e, void 0, n.extend({},
                    t, {
                        unset: !0
                    }))
                },
                clear: function (e) {
                    var t = {};
                    for (var i in this.attributes) t[i] = void 0;
                    return this.set(t, n.extend({},
                    e, {
                        unset: !0
                    }))
                },
                hasChanged: function (e) {
                    return null == e ? !n.isEmpty(this.changed) : n.has(this.changed, e)
                },
                changedAttributes: function (e) {
                    if (!e) return this.hasChanged() ? n.clone(this.changed) : !1;
                    var t, i = !1,
                    r = this._changing ? this._previousAttributes : this.attributes;
                    for (var o in e) n.isEqual(r[o], t = e[o]) || ((i || (i = {}))[o] = t);
                    return i
                },
                previous: function (e) {
                    return null != e && this._previousAttributes ? this._previousAttributes[e] : null
                },
                previousAttributes: function () {
                    return n.clone(this._previousAttributes)
                },
                fetch: function (e) {
                    e = e ? n.clone(e) : {},
                    void 0 === e.parse && (e.parse = !0);
                    var t = this,
                    i = e.success;
                    return e.success = function (n) {
                        return t.set(t.parse(n, e), e) ? (i && i(t, n, e), void t.trigger("sync", t, n, e)) : !1
                    },
                    $(this, e),
                    this.sync("read", this, e)
                },
                save: function (e, t, i) {
                    var r, o, a, s = this.attributes;
                    if (null == e || "object" == typeof e ? (r = e, i = t) : (r = {})[e] = t, i = n.extend({
                        validate: !0
                    },
                    i), r && !i.wait) {
                        if (!this.set(r, i)) return !1
                    } else if (!this._validate(r, i)) return !1;
                    r && i.wait && (this.attributes = n.extend({},
                    s, r)),
                    void 0 === i.parse && (i.parse = !0);
                    var u = this,
                    c = i.success;
                    return i.success = function (e) {
                        u.attributes = s;
                        var t = u.parse(e, i);
                        return i.wait && (t = n.extend(r || {},
                        t)),
                        n.isObject(t) && !u.set(t, i) ? !1 : (c && c(u, e, i), void u.trigger("sync", u, e, i))
                    },
                    $(this, i),
                    o = this.isNew() ? "create" : i.patch ? "patch" : "update",
                    "patch" === o && (i.attrs = r),
                    a = this.sync(o, this, i),
                    r && i.wait && (this.attributes = s),
                    a
                },
                destroy: function (e) {
                    e = e ? n.clone(e) : {};
                    var t = this,
                    i = e.success,
                    r = function () {
                        t.trigger("destroy", t, t.collection, e)
                    };
                    if (e.success = function (n) {
                    (e.wait || t.isNew()) && r(),
                        i && i(t, n, e),
                        t.isNew() || t.trigger("sync", t, n, e)
                    },
                    this.isNew()) return e.success(),
                    !1;
                    $(this, e);
                    var o = this.sync("delete", this, e);
                    return e.wait || r(),
                    o
                },
                url: function () {
                    var e = n.result(this, "urlRoot") || n.result(this.collection, "url") || M();
                    return this.isNew() ? e : e.replace(/([^\/])$/, "$1/") + encodeURIComponent(this.id)
                },
                parse: function (e, t) {
                    return e
                },
                clone: function () {
                    return new this.constructor(this.attributes)
                },
                isNew: function () {
                    return !this.has(this.idAttribute)
                },
                isValid: function (e) {
                    return this._validate({},
                    n.extend(e || {},
                    {
                        validate: !0
                    }))
                },
                _validate: function (e, t) {
                    if (!t.validate || !this.validate) return !0;
                    e = n.extend({},
                    this.attributes, e);
                    var i = this.validationError = this.validate(e, t) || null;
                    return i ? (this.trigger("invalid", this, i, n.extend(t, {
                        validationError: i
                    })), !1) : !0
                }
            });
            var p = ["keys", "values", "pairs", "invert", "pick", "omit"];
            n.each(p,
            function (e) {
                d.prototype[e] = function () {
                    var t = a.call(arguments);
                    return t.unshift(this.attributes),
                    n[e].apply(n, t)
                }
            });
            var h = t.Collection = function (e, t) {
                t || (t = {}),
                t.model && (this.model = t.model),
                void 0 !== t.comparator && (this.comparator = t.comparator),
                this._reset(),
                this.initialize.apply(this, arguments),
                e && this.reset(e, n.extend({
                    silent: !0
                },
                t))
            },
            g = {
                add: !0,
                remove: !0,
                merge: !0
            },
            m = {
                add: !0,
                remove: !1
            };
            n.extend(h.prototype, s, {
                model: d,
                initialize: function () { },
                toJSON: function (e) {
                    return this.map(function (t) {
                        return t.toJSON(e)
                    })
                },
                sync: function () {
                    return t.sync.apply(this, arguments)
                },
                add: function (e, t) {
                    return this.set(e, n.extend({
                        merge: !1
                    },
                    t, m))
                },
                remove: function (e, t) {
                    var i = !n.isArray(e);
                    e = i ? [e] : n.clone(e),
                    t || (t = {});
                    var r, o, a, s;
                    for (r = 0, o = e.length; o > r; r++) s = e[r] = this.get(e[r]),
                    s && (delete this._byId[s.id], delete this._byId[s.cid], a = this.indexOf(s), this.models.splice(a, 1), this.length--, t.silent || (t.index = a, s.trigger("remove", s, this, t)), this._removeReference(s, t));
                    return i ? e[0] : e
                },
                set: function (e, t) {
                    t = n.defaults({},
                    t, g),
                    t.parse && (e = this.parse(e, t));
                    var i = !n.isArray(e);
                    e = i ? e ? [e] : [] : n.clone(e);
                    var r, o, a, s, u, c, l, f = t.at,
                    p = this.model,
                    h = this.comparator && null == f && t.sort !== !1,
                    m = n.isString(this.comparator) ? this.comparator : null,
                    v = [],
                    y = [],
                    x = {},
                    w = t.add,
                    b = t.merge,
                    k = t.remove,
                    T = !h && w && k ? [] : !1;
                    for (r = 0, o = e.length; o > r; r++) {
                        if (u = e[r] || {},
                        a = u instanceof d ? s = u : u[p.prototype.idAttribute || "id"], c = this.get(a)) k && (x[c.cid] = !0),
                        b && (u = u === s ? s.attributes : u, t.parse && (u = c.parse(u, t)), c.set(u, t), h && !l && c.hasChanged(m) && (l = !0)),
                        e[r] = c;
                        else if (w) {
                            if (s = e[r] = this._prepareModel(u, t), !s) continue;
                            v.push(s),
                            this._addReference(s, t)
                        }
                        s = c || s,
                        !T || !s.isNew() && x[s.id] || T.push(s),
                        x[s.id] = !0
                    }
                    if (k) {
                        for (r = 0, o = this.length; o > r; ++r) x[(s = this.models[r]).cid] || y.push(s);
                        y.length && this.remove(y, t)
                    }
                    if (v.length || T && T.length) if (h && (l = !0), this.length += v.length, null != f) for (r = 0, o = v.length; o > r; r++) this.models.splice(f + r, 0, v[r]);
                    else {
                        T && (this.models.length = 0);
                        var S = T || v;
                        for (r = 0, o = S.length; o > r; r++) this.models.push(S[r])
                    }
                    if (l && this.sort({
                        silent: !0
                    }), !t.silent) {
                        for (r = 0, o = v.length; o > r; r++) (s = v[r]).trigger("add", s, this, t); (l || T && T.length) && this.trigger("sort", this, t)
                    }
                    return i ? e[0] : e
                },
                reset: function (e, t) {
                    t || (t = {});
                    for (var i = 0,
                    r = this.models.length; r > i; i++) this._removeReference(this.models[i], t);
                    return t.previousModels = this.models,
                    this._reset(),
                    e = this.add(e, n.extend({
                        silent: !0
                    },
                    t)),
                    t.silent || this.trigger("reset", this, t),
                    e
                },
                push: function (e, t) {
                    return this.add(e, n.extend({
                        at: this.length
                    },
                    t))
                },
                pop: function (e) {
                    var t = this.at(this.length - 1);
                    return this.remove(t, e),
                    t
                },
                unshift: function (e, t) {
                    return this.add(e, n.extend({
                        at: 0
                    },
                    t))
                },
                shift: function (e) {
                    var t = this.at(0);
                    return this.remove(t, e),
                    t
                },
                slice: function () {
                    return a.apply(this.models, arguments)
                },
                get: function (e) {
                    return null == e ? void 0 : this._byId[e] || this._byId[e.id] || this._byId[e.cid]
                },
                at: function (e) {
                    return this.models[e]
                },
                where: function (e, t) {
                    return n.isEmpty(e) ? t ? void 0 : [] : this[t ? "find" : "filter"](function (t) {
                        for (var n in e) if (e[n] !== t.get(n)) return !1;
                        return !0
                    })
                },
                findWhere: function (e) {
                    return this.where(e, !0)
                },
                sort: function (e) {
                    if (!this.comparator) throw new Error("Cannot sort a set without a comparator");
                    return e || (e = {}),
                    n.isString(this.comparator) || 1 === this.comparator.length ? this.models = this.sortBy(this.comparator, this) : this.models.sort(n.bind(this.comparator, this)),
                    e.silent || this.trigger("sort", this, e),
                    this
                },
                pluck: function (e) {
                    return n.invoke(this.models, "get", e)
                },
                fetch: function (e) {
                    e = e ? n.clone(e) : {},
                    void 0 === e.parse && (e.parse = !0);
                    var t = e.success,
                    i = this;
                    return e.success = function (n) {
                        var r = e.reset ? "reset" : "set";
                        i[r](n, e),
                        t && t(i, n, e),
                        i.trigger("sync", i, n, e)
                    },
                    $(this, e),
                    this.sync("read", this, e)
                },
                create: function (e, t) {
                    if (t = t ? n.clone(t) : {},
                    !(e = this._prepareModel(e, t))) return !1;
                    t.wait || this.add(e, t);
                    var i = this,
                    r = t.success;
                    return t.success = function (e, n) {
                        t.wait && i.add(e, t),
                        r && r(e, n, t)
                    },
                    e.save(null, t),
                    e
                },
                parse: function (e, t) {
                    return e
                },
                clone: function () {
                    return new this.constructor(this.models)
                },
                _reset: function () {
                    this.length = 0,
                    this.models = [],
                    this._byId = {}
                },
                _prepareModel: function (e, t) {
                    if (e instanceof d) return e;
                    t = t ? n.clone(t) : {},
                    t.collection = this;
                    var i = new this.model(e, t);
                    return i.validationError ? (this.trigger("invalid", this, i.validationError, t), !1) : i
                },
                _addReference: function (e, t) {
                    this._byId[e.cid] = e,
                    null != e.id && (this._byId[e.id] = e),
                    e.collection || (e.collection = this),
                    e.on("all", this._onModelEvent, this)
                },
                _removeReference: function (e, t) {
                    this === e.collection && delete e.collection,
                    e.off("all", this._onModelEvent, this)
                },
                _onModelEvent: function (e, t, n, i) {
                    ("add" !== e && "remove" !== e || n === this) && ("destroy" === e && this.remove(t, i), t && e === "change:" + t.idAttribute && (delete this._byId[t.previous(t.idAttribute)], null != t.id && (this._byId[t.id] = t)), this.trigger.apply(this, arguments))
                }
            });
            var v = ["forEach", "each", "map", "collect", "reduce", "foldl", "inject", "reduceRight", "foldr", "find", "detect", "filter", "select", "reject", "every", "all", "some", "any", "include", "contains", "invoke", "max", "min", "toArray", "size", "first", "head", "take", "initial", "rest", "tail", "drop", "last", "without", "difference", "indexOf", "shuffle", "lastIndexOf", "isEmpty", "chain", "sample"];
            n.each(v,
            function (e) {
                h.prototype[e] = function () {
                    var t = a.call(arguments);
                    return t.unshift(this.models),
                    n[e].apply(n, t)
                }
            });
            var y = ["groupBy", "countBy", "sortBy", "indexBy"];
            n.each(y,
            function (e) {
                h.prototype[e] = function (t, i) {
                    var r = n.isFunction(t) ? t : function (e) {
                        return e.get(t)
                    };
                    return n[e](this.models, r, i)
                }
            });
            var x = t.View = function (e) {
                this.cid = n.uniqueId("view"),
                e || (e = {}),
                n.extend(this, n.pick(e, b)),
                this._ensureElement(),
                this.initialize.apply(this, arguments),
                this.delegateEvents()
            },
            w = /^(\S+)\s*(.*)$/,
            b = ["model", "collection", "el", "id", "attributes", "className", "tagName", "events"];
            n.extend(x.prototype, s, {
                tagName: "div",
                $: function (e) {
                    return this.$el.find(e)
                },
                initialize: function () { },
                render: function () {
                    return this
                },
                remove: function () {
                    return this.$el.remove(),
                    this.stopListening(),
                    this
                },
                setElement: function (e, n) {
                    return this.$el && this.undelegateEvents(),
                    this.$el = e instanceof t.$ ? e : t.$(e),
                    this.el = this.$el[0],
                    n !== !1 && this.delegateEvents(),
                    this
                },
                delegateEvents: function (e) {
                    if (!e && !(e = n.result(this, "events"))) return this;
                    this.undelegateEvents();
                    for (var t in e) {
                        var i = e[t];
                        if (n.isFunction(i) || (i = this[e[t]]), i) {
                            var r = t.match(w),
                            o = r[1],
                            a = r[2];
                            i = n.bind(i, this),
                            o += ".delegateEvents" + this.cid,
                            "" === a ? this.$el.on(o, i) : this.$el.on(o, a, i)
                        }
                    }
                    return this
                },
                undelegateEvents: function () {
                    return this.$el.off(".delegateEvents" + this.cid),
                    this
                },
                _ensureElement: function () {
                    if (this.el) this.setElement(n.result(this, "el"), !1);
                    else {
                        var e = n.extend({},
                        n.result(this, "attributes"));
                        this.id && (e.id = n.result(this, "id")),
                        this.className && (e["class"] = n.result(this, "className"));
                        var i = t.$("<" + n.result(this, "tagName") + ">").attr(e);
                        this.setElement(i, !1)
                    }
                }
            }),
            t.sync = function (e, i, r) {
                var o = T[e];
                n.defaults(r || (r = {}), {
                    emulateHTTP: t.emulateHTTP,
                    emulateJSON: t.emulateJSON
                });
                var a = {
                    type: o,
                    dataType: "json"
                };
                if (r.url || (a.url = n.result(i, "url") || M()), null != r.data || !i || "create" !== e && "update" !== e && "patch" !== e || (a.contentType = "application/json", a.data = JSON.stringify(r.attrs || i.toJSON(r))), r.emulateJSON && (a.contentType = "application/x-www-form-urlencoded", a.data = a.data ? {
                    model: a.data
                } : {}), r.emulateHTTP && ("PUT" === o || "DELETE" === o || "PATCH" === o)) {
                    a.type = "POST",
                    r.emulateJSON && (a.data._method = o);
                    var s = r.beforeSend;
                    r.beforeSend = function (e) {
                        return e.setRequestHeader("X-HTTP-Method-Override", o),
                        s ? s.apply(this, arguments) : void 0
                    }
                }
                "GET" === a.type || r.emulateJSON || (a.processData = !1),
                "PATCH" === a.type && k && (a.xhr = function () {
                    return new ActiveXObject("Microsoft.XMLHTTP")
                });
                var u = r.xhr = t.ajax(n.extend(a, r));
                return i.trigger("request", i, u, r),
                u
            };
            var k = !("undefined" == typeof window || !window.ActiveXObject || window.XMLHttpRequest && (new XMLHttpRequest).dispatchEvent),
            T = {
                create: "POST",
                update: "PUT",
                patch: "PATCH",
                "delete": "DELETE",
                read: "GET"
            };
            t.ajax = function () {
                return t.$.ajax.apply(t.$, arguments)
            };
            var S = t.Router = function (e) {
                e || (e = {}),
                e.routes && (this.routes = e.routes),
                this._bindRoutes(),
                this.initialize.apply(this, arguments)
            },
            C = /\((.*?)\)/g,
            _ = /(\(\?)?:\w+/g,
            j = /\*\w+/g,
            E = /[\-{}\[\]+?.,\\\^$|#\s]/g;
            n.extend(S.prototype, s, {
                initialize: function () { },
                route: function (e, i, r) {
                    n.isRegExp(e) || (e = this._routeToRegExp(e)),
                    n.isFunction(i) && (r = i, i = ""),
                    r || (r = this[i]);
                    var o = this;
                    return t.history.route(e,
                    function (n) {
                        var a = o._extractParameters(e, n);
                        o.execute(r, a),
                        o.trigger.apply(o, ["route:" + i].concat(a)),
                        o.trigger("route", i, a),
                        t.history.trigger("route", o, i, a)
                    }),
                    this
                },
                execute: function (e, t) {
                    e && e.apply(this, t)
                },
                navigate: function (e, n) {
                    return t.history.navigate(e, n),
                    this
                },
                _bindRoutes: function () {
                    if (this.routes) {
                        this.routes = n.result(this, "routes");
                        for (var e, t = n.keys(this.routes) ; null != (e = t.pop()) ;) this.route(e, this.routes[e])
                    }
                },
                _routeToRegExp: function (e) {
                    return e = e.replace(E, "\\$&").replace(C, "(?:$1)?").replace(_,
                    function (e, t) {
                        return t ? e : "([^/?]+)"
                    }).replace(j, "([^?]*?)"),
                    new RegExp("^" + e + "(?:\\?([\\s\\S]*))?$")
                },
                _extractParameters: function (e, t) {
                    var i = e.exec(t).slice(1);
                    return n.map(i,
                    function (e, t) {
                        return t === i.length - 1 ? e || null : e ? decodeURIComponent(e) : null
                    })
                }
            });
            var N = t.History = function () {
                this.handlers = [],
                n.bindAll(this, "checkUrl"),
                "undefined" != typeof window && (this.location = window.location, this.history = window.history)
            },
            A = /^[#\/]|\s+$/g,
            O = /^\/+|\/+$/g,
            D = /msie [\w.]+/,
            I = /\/$/,
            q = /#.*$/;
            N.started = !1,
            n.extend(N.prototype, s, {
                interval: 50,
                atRoot: function () {
                    return this.location.pathname.replace(/[^\/]$/, "$&/") === this.root
                },
                getHash: function (e) {
                    var t = (e || this).location.href.match(/#(.*)$/);
                    return t ? t[1] : ""
                },
                getFragment: function (e, t) {
                    if (null == e) if (this._hasPushState || !this._wantsHashChange || t) {
                        e = decodeURI(this.location.pathname + this.location.search);
                        var n = this.root.replace(I, "");
                        e.indexOf(n) || (e = e.slice(n.length))
                    } else e = this.getHash();
                    return e.replace(A, "")
                },
                start: function (e) {
                    if (N.started) throw new Error("Backbone.history has already been started");
                    N.started = !0,
                    this.options = n.extend({
                        root: "/"
                    },
                    this.options, e),
                    this.root = this.options.root,
                    this._wantsHashChange = this.options.hashChange !== !1,
                    this._wantsPushState = !!this.options.pushState,
                    this._hasPushState = !!(this.options.pushState && this.history && this.history.pushState);
                    var i = this.getFragment(),
                    r = document.documentMode,
                    o = D.exec(navigator.userAgent.toLowerCase()) && (!r || 7 >= r);
                    if (this.root = ("/" + this.root + "/").replace(O, "/"), o && this._wantsHashChange) {
                        var a = t.$('<iframe src="javascript:0" tabindex="-1">');
                        this.iframe = a.hide().appendTo("body")[0].contentWindow,
                        this.navigate(i)
                    }
                    this._hasPushState ? t.$(window).on("popstate", this.checkUrl) : this._wantsHashChange && "onhashchange" in window && !o ? t.$(window).on("hashchange", this.checkUrl) : this._wantsHashChange && (this._checkUrlInterval = setInterval(this.checkUrl, this.interval)),
                    this.fragment = i;
                    var s = this.location;
                    if (this._wantsHashChange && this._wantsPushState) {
                        if (!this._hasPushState && !this.atRoot()) return this.fragment = this.getFragment(null, !0),
                        this.location.replace(this.root + "#" + this.fragment),
                        !0;
                        this._hasPushState && this.atRoot() && s.hash && (this.fragment = this.getHash().replace(A, ""), this.history.replaceState({},
                        document.title, this.root + this.fragment))
                    }
                    return this.options.silent ? void 0 : this.loadUrl()
                },
                stop: function () {
                    t.$(window).off("popstate", this.checkUrl).off("hashchange", this.checkUrl),
                    this._checkUrlInterval && clearInterval(this._checkUrlInterval),
                    N.started = !1
                },
                route: function (e, t) {
                    this.handlers.unshift({
                        route: e,
                        callback: t
                    })
                },
                checkUrl: function (e) {
                    var t = this.getFragment();
                    return t === this.fragment && this.iframe && (t = this.getFragment(this.getHash(this.iframe))),
                    t === this.fragment ? !1 : (this.iframe && this.navigate(t), void this.loadUrl())
                },
                loadUrl: function (e) {
                    return e = this.fragment = this.getFragment(e),
                    n.any(this.handlers,
                    function (t) {
                        return t.route.test(e) ? (t.callback(e), !0) : void 0
                    })
                },
                navigate: function (e, t) {
                    if (!N.started) return !1;
                    t && t !== !0 || (t = {
                        trigger: !!t
                    });
                    var n = this.root + (e = this.getFragment(e || ""));
                    if (e = e.replace(q, ""), this.fragment !== e) {
                        if (this.fragment = e, "" === e && "/" !== n && (n = n.slice(0, -1)), this._hasPushState) this.history[t.replace ? "replaceState" : "pushState"]({},
                        document.title, n);
                        else {
                            if (!this._wantsHashChange) return this.location.assign(n);
                            this._updateHash(this.location, e, t.replace),
                            this.iframe && e !== this.getFragment(this.getHash(this.iframe)) && (t.replace || this.iframe.document.open().close(), this._updateHash(this.iframe.location, e, t.replace))
                        }
                        return t.trigger ? this.loadUrl(e) : void 0
                    }
                },
                _updateHash: function (e, t, n) {
                    if (n) {
                        var i = e.href.replace(/(javascript:|#).*$/, "");
                        e.replace(i + "#" + t)
                    } else e.hash = "#" + t
                }
            }),
            t.history = new N;
            var L = function (e, t) {
                var i, r = this;
                i = e && n.has(e, "constructor") ? e.constructor : function () {
                    return r.apply(this, arguments)
                },
                n.extend(i, r, t);
                var o = function () {
                    this.constructor = i
                };
                return o.prototype = r.prototype,
                i.prototype = new o,
                e && n.extend(i.prototype, e),
                i.__super__ = r.prototype,
                i
            };
            d.extend = h.extend = S.extend = x.extend = N.extend = L;
            var M = function () {
                throw new Error('A "url" property or function must be specified')
            },
            $ = function (e, t) {
                var n = t.error;
                t.error = function (i) {
                    n && n(e, i, t),
                    e.trigger("error", e, i, t)
                }
            };
            return t
        })
}.call(this),
define("base", [],
function () {
    var e = {};
    return e.ui = {
        createWait: function () {
            var e = document.createElement("div");
            e.className = "base-ui-wait",
			document.body.appendChild(e)
        },
        closeWait: function () {
            var e = document.querySelector(".base-ui-wait");
            e.parentNode.removeChild(e)
        },
        alert: function (e, t) {
            if (!e) return !1;
            var n = null,
			i = null,
			r = document.createElement("div");
            r.className = "base-ui-alert",
			r.innerHTML = '<div class="modal"><div class="modal-inner">' + e + '</div><div class="modal-btns"><a href="javascript:;" class="modal-btn confirm-ok">确认</a></div></div>',
			document.body.appendChild(r);
            var o = function () {
                r.parentNode.removeChild(r),
				"function" == typeof t && t()
            };
            r.classList.add("modal-in"),
			n = r.querySelector(".modal-inner"),
			i = r.querySelector(".confirm-ok"),
			i.addEventListener("click", o, !1)
        },
        confirm: function (e, t, n) {
            if (!e) return !1;
            var i = document.querySelector(".base-ui-confirm"),
			r = null,
			o = null,
			a = null,
			s = !0;
            i ? s = !1 : (i = document.createElement("div"), i.className = "base-ui-confirm", i.innerHTML = '<div class="modal"><div class="modal-inner">' + e + '</div><div class="modal-btns"><a href="javascript:;" class="modal-btn confirm-cancel">取消</a><a href="javascript:;" class="modal-btn confirm-ok">确认</a></div></div>', document.body.appendChild(i)),
			i.classList.add("modal-in"),
			r = i.querySelector(".modal-inner"),
			o = i.querySelector(".confirm-ok"),
			a = i.querySelector(".confirm-cancel");
            var u = function () {
                s ? i.parentNode.removeChild(i) : (i.classList.remove("modal-in"), a.removeEventListener("click", c, !1), o.removeEventListener("click", l, !1))
            },
			c = u;
            "function" == typeof n && (c = function () {
                n(),
				u()
            });
            var l = function () {
                u(),
				"function" == typeof t && t()
            };
            a.addEventListener("click", c, !1),
			o.addEventListener("click", l, !1)
        }
    },
	e.tool = {
	    randomArr: function (e, t) {
	        var n = new Array;
	        for (var i in e) n.push(e[i]);
	        for (var r = new Array,
			o = 0; t > o && n.length > 0; o++) {
	            var a = Math.floor(Math.random() * n.length);
	            r[o] = n[a],
				n.splice(a, 1)
	        }
	        return r
	    },
	    cookie: function () {
	        return {
	            set: function (t, n, i) {
	                if (!i && e.device.hasLocalStorage) return localStorage[t] = n,
					!1;
	                var r = new Date;
	                i = i || 1e4,
					r.setDate(r.getDate() + i),
					document.cookie = t + "=" + n + ";expires=" + r
	            },
	            get: function (t, n) {
	                if (!n && e.device.hasLocalStorage) return localStorage[t] || "";
	                var i, r = new RegExp("(^| )" + t + "=([^;]*)(;|$)");
	                return (i = document.cookie.match(r)) ? unescape(i[2]) : ""
	            },
	            remove: function (t, n) {
	                return !n && e.device.hasLocalStorage ? (localStorage.removeItem(t), !1) : void this.setCookie(t, "1", -1)
	            }
	        }
	    }(),
	    unserialize: function (e) {
	        for (var t = /([^=&\s]+)[=\s]*([^=&\s]*)/g,
			n = {}; t.exec(e) ;) n[RegExp.$1] = RegExp.$2;
	        return n
	    }
	},
	e.device = {
	    hasLocalStorage: "undefined" != typeof localStorage && !!localStorage && "function" == typeof localStorage.getItem,
	    isWeixin: -1 !== window.navigator.userAgent.search(/MicroMessenger/i),
	    isIOS: /(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent)
	},
	e.regexp = {
	    phone: function (e) {
	        return -1 !== e.search(/^(13|15|17|18|19)\d{9}$/g)
	    }
	},
	e
}),
!
function () {
    var e = function () {
        var t = [].slice.call(arguments);
        return t.push(e.options),
		t[0].match(/^\s*#([\w:\-\.]+)\s*$/gim) && t[0].replace(/^\s*#([\w:\-\.]+)\s*$/gim,
		function (e, n) {
		    var i = document,
			r = i && i.getElementById(n);
		    t[0] = r ? r.value || r.innerHTML : e
		}),
		"undefined" != typeof document && document.body && e.compile.call(e, document.body.innerHTML),
		1 == arguments.length ? e.compile.apply(e, t) : arguments.length >= 2 ? e.to_html.apply(e, t) : void 0
    },
	t = {
	    escapehash: {
	        "<": "&lt;",
	        ">": "&gt;",
	        "&": "&amp;",
	        '"': "&quot;",
	        "'": "&#x27;",
	        "/": "&#x2f;"
	    },
	    escapereplace: function (e) {
	        return t.escapehash[e]
	    },
	    escaping: function (e) {
	        return "string" != typeof e ? e : e.replace(/[&<>"]/gim, this.escapereplace)
	    },
	    detection: function (e) {
	        return "undefined" == typeof e ? "" : e
	    }
	},
	n = function (e) {
	    if ("undefined" != typeof console) {
	        if (console.warn) return void console.warn(e);
	        if (console.log) return void console.log(e)
	    }
	    throw e
	},
	i = function (e, t) {
	    if (e = e !== Object(e) ? {} : e, e.__proto__) return e.__proto__ = t,
		e;
	    var n = function () { },
		i = Object.create ? Object.create(t) : new (n.prototype = t, n);
	    for (var r in e) e.hasOwnProperty(r) && (i[r] = e[r]);
	    return i
	},
	r = function (e) {
	    var t, n, i, r = /^function\s*[^\(]*\(\s*([^\)]*)\)/m,
		o = /,/,
		a = /^\s*(_?)(\S+?)\1\s*$/,
		s = /^function[^{]+{([\s\S]*)}/m,
		u = [];
	    "function" == typeof e ? e.length && (t = e.toString()) : "string" == typeof e && (t = e),
		t = t.trim(),
		i = t.match(r),
		n = t.match(s)[1].trim();
	    for (var c = 0; c < i[1].split(o).length; c++) {
	        var l = i[1].split(o)[c];
	        l.replace(a,
			function (e, t, n) {
			    u.push(n)
			})
	    }
	    return [u, n]
	};
    e.__cache = {},
	e.version = "0.6.9-stable",
	e.settings = {},
	e.tags = {
	    operationOpen: "{@",
	    operationClose: "}",
	    interpolateOpen: "\\${",
	    interpolateClose: "}",
	    noneencodeOpen: "\\$\\${",
	    noneencodeClose: "}",
	    commentOpen: "\\{#",
	    commentClose: "\\}"
	},
	e.options = {
	    cache: !0,
	    strip: !0,
	    errorhandling: !0,
	    detection: !0,
	    _method: i({
	        __escapehtml: t,
	        __throw: n,
	        __juicer: e
	    },
		{})
	},
	e.tagInit = function () {
	    var t = e.tags.operationOpen + "each\\s*([^}]*?)\\s*as\\s*(\\w*?)\\s*(,\\s*\\w*?)?" + e.tags.operationClose,
		n = e.tags.operationOpen + "\\/each" + e.tags.operationClose,
		i = e.tags.operationOpen + "if\\s*([^}]*?)" + e.tags.operationClose,
		r = e.tags.operationOpen + "\\/if" + e.tags.operationClose,
		o = e.tags.operationOpen + "else" + e.tags.operationClose,
		a = e.tags.operationOpen + "else if\\s*([^}]*?)" + e.tags.operationClose,
		s = e.tags.interpolateOpen + "([\\s\\S]+?)" + e.tags.interpolateClose,
		u = e.tags.noneencodeOpen + "([\\s\\S]+?)" + e.tags.noneencodeClose,
		c = e.tags.commentOpen + "[^}]*?" + e.tags.commentClose,
		l = e.tags.operationOpen + "each\\s*(\\w*?)\\s*in\\s*range\\(([^}]+?)\\s*,\\s*([^}]+?)\\)" + e.tags.operationClose,
		f = e.tags.operationOpen + "include\\s*([^}]*?)\\s*,\\s*([^}]*?)" + e.tags.operationClose,
		d = e.tags.operationOpen + "helper\\s*([^}]*?)\\s*" + e.tags.operationClose,
		p = "([\\s\\S]*?)",
		h = e.tags.operationOpen + "\\/helper" + e.tags.operationClose;
	    e.settings.forstart = new RegExp(t, "igm"),
		e.settings.forend = new RegExp(n, "igm"),
		e.settings.ifstart = new RegExp(i, "igm"),
		e.settings.ifend = new RegExp(r, "igm"),
		e.settings.elsestart = new RegExp(o, "igm"),
		e.settings.elseifstart = new RegExp(a, "igm"),
		e.settings.interpolate = new RegExp(s, "igm"),
		e.settings.noneencode = new RegExp(u, "igm"),
		e.settings.inlinecomment = new RegExp(c, "igm"),
		e.settings.rangestart = new RegExp(l, "igm"),
		e.settings.include = new RegExp(f, "igm"),
		e.settings.helperRegister = new RegExp(d + p + h, "igm")
	},
	e.tagInit(),
	e.set = function (e, t) {
	    var n = this,
		i = function (e) {
		    return e.replace(/[\$\(\)\[\]\+\^\{\}\?\*\|\.]/gim,
			function (e) {
			    return "\\" + e
			})
		},
		r = function (e, t) {
		    var r = e.match(/^tag::(.*)$/i);
		    return r ? (n.tags[r[1]] = i(t), void n.tagInit()) : void (n.options[e] = t)
		};
	    if (2 === arguments.length) return void r(e, t);
	    if (e === Object(e)) for (var o in e) e.hasOwnProperty(o) && r(o, e[o])
	},
	e.register = function (e, t) {
	    var n = this.options._method;
	    return n.hasOwnProperty(e) ? !1 : n[e] = t
	},
	e.unregister = function (e) {
	    var t = this.options._method;
	    return t.hasOwnProperty(e) ? delete t[e] : void 0
	},
	e.template = function (t) {
	    var n = this;
	    this.options = t,
		this.__interpolate = function (e, t, n) {
		    var i, r = e.split("|"),
			o = r[0] || "";
		    return r.length > 1 && (e = r.shift(), i = r.shift().split(","), o = "_method." + i.shift() + ".call({}, " + [e].concat(i) + ")"),
			"<%= " + (t ? "_method.__escapehtml.escaping" : "") + "(" + (n && n.detection === !1 ? "" : "_method.__escapehtml.detection") + "(" + o + ")) %>"
		},
		this.__removeShell = function (t, i) {
		    var o = 0;
		    return t = t.replace(e.settings.helperRegister,
			function (t, n, i) {
			    var o = r(i),
				a = o[0],
				s = o[1],
				u = new Function(a.join(","), s);
			    return e.register(n, u),
				t
			}).replace(e.settings.forstart,
			function (e, t, n, i) {
			    var n = n || "value",
				i = i && i.substr(1),
				r = "i" + o++;
			    return "<% ~function() {for(var " + r + " in " + t + ") {if(" + t + ".hasOwnProperty(" + r + ")) {var " + n + "=" + t + "[" + r + "];" + (i ? "var " + i + "=" + r + ";" : "") + " %>"
			}).replace(e.settings.forend, "<% }}}(); %>").replace(e.settings.ifstart,
			function (e, t) {
			    return "<% if(" + t + ") { %>"
			}).replace(e.settings.ifend, "<% } %>").replace(e.settings.elsestart,
			function (e) {
			    return "<% } else { %>"
			}).replace(e.settings.elseifstart,
			function (e, t) {
			    return "<% } else if(" + t + ") { %>"
			}).replace(e.settings.noneencode,
			function (e, t) {
			    return n.__interpolate(t, !1, i)
			}).replace(e.settings.interpolate,
			function (e, t) {
			    return n.__interpolate(t, !0, i)
			}).replace(e.settings.inlinecomment, "").replace(e.settings.rangestart,
			function (e, t, n, i) {
			    var r = "j" + o++;
			    return "<% ~function() {for(var " + r + "=" + n + ";" + r + "<" + i + ";" + r + "++) {{var " + t + "=" + r + "; %>"
			}).replace(e.settings.include,
			function (e, t, n) {
			    return t.match(/^file\:\/\//gim) ? e : "<%= _method.__juicer(" + t + ", " + n + "); %>"
			}),
			i && i.errorhandling === !1 || (t = "<% try { %>" + t, t += '<% } catch(e) {_method.__throw("Juicer Render Exception: "+e.message);} %>'),
			t
		},
		this.__toNative = function (e, t) {
		    return this.__convert(e, !t || t.strip)
		},
		this.__lexicalAnalyze = function (t) {
		    var n = [],
			i = [],
			r = "",
			o = ["if", "each", "_", "_method", "console", "break", "case", "catch", "continue", "debugger", "default", "delete", "do", "finally", "for", "function", "in", "instanceof", "new", "return", "switch", "this", "throw", "try", "typeof", "var", "void", "while", "with", "null", "typeof", "class", "enum", "export", "extends", "import", "super", "implements", "interface", "let", "package", "private", "protected", "public", "static", "yield", "const", "arguments", "true", "false", "undefined", "NaN"],
			a = function (e, t) {
			    if (Array.prototype.indexOf && e.indexOf === Array.prototype.indexOf) return e.indexOf(t);
			    for (var n = 0; n < e.length; n++) if (e[n] === t) return n;
			    return -1
			},
			s = function (t, r) {
			    if (r = r.match(/\w+/gim)[0], -1 === a(n, r) && -1 === a(o, r) && -1 === a(i, r)) {
			        if ("undefined" != typeof window && "function" == typeof window[r] && window[r].toString().match(/^\s*?function \w+\(\) \{\s*?\[native code\]\s*?\}\s*?$/i)) return t;
			        if ("undefined" != typeof global && "function" == typeof global[r] && global[r].toString().match(/^\s*?function \w+\(\) \{\s*?\[native code\]\s*?\}\s*?$/i)) return t;
			        if ("function" == typeof e.options._method[r] || e.options._method.hasOwnProperty(r)) return i.push(r),
					t;
			        n.push(r)
			    }
			    return t
			};
		    t.replace(e.settings.forstart, s).replace(e.settings.interpolate, s).replace(e.settings.ifstart, s).replace(e.settings.elseifstart, s).replace(e.settings.include, s).replace(/[\+\-\*\/%!\?\|\^&~<>=,\(\)\[\]]\s*([A-Za-z_]+)/gim, s);
		    for (var u = 0; u < n.length; u++) r += "var " + n[u] + "=_." + n[u] + ";";
		    for (var u = 0; u < i.length; u++) r += "var " + i[u] + "=_method." + i[u] + ";";
		    return "<% " + r + " %>"
		},
		this.__convert = function (e, t) {
		    var n = [].join("");
		    return n += "'use strict';",
			n += "var _=_||{};",
			n += "var _out='';_out+='",
			n += t !== !1 ? e.replace(/\\/g, "\\\\").replace(/[\r\t\n]/g, " ").replace(/'(?=[^%]*%>)/g, "	").split("'").join("\\'").split("	").join("'").replace(/<%=(.+?)%>/g, "';_out+=$1;_out+='").split("<%").join("';").split("%>").join("_out+='") + "';return _out;" : e.replace(/\\/g, "\\\\").replace(/[\r]/g, "\\r").replace(/[\t]/g, "\\t").replace(/[\n]/g, "\\n").replace(/'(?=[^%]*%>)/g, "	").split("'").join("\\'").split("	").join("'").replace(/<%=(.+?)%>/g, "';_out+=$1;_out+='").split("<%").join("';").split("%>").join("_out+='") + "';return _out.replace(/[\\r\\n]\\s+[\\r\\n]/g, '\\r\\n');"
		},
		this.parse = function (e, t) {
		    var r = this;
		    return t && t.loose === !1 || (e = this.__lexicalAnalyze(e) + e),
			e = this.__removeShell(e, t),
			e = this.__toNative(e, t),
			this._render = new Function("_, _method", e),
			this.render = function (e, t) {
			    return t && t === n.options._method || (t = i(t, n.options._method)),
				r._render.call(this, e, t)
			},
			this
		}
	},
	e.compile = function (e, t) {
	    t && t === this.options || (t = i(t, this.options));
	    try {
	        var r = this.__cache[e] ? this.__cache[e] : new this.template(this.options).parse(e, t);
	        return t && t.cache === !1 || (this.__cache[e] = r),
			r
	    } catch (o) {
	        return n("Juicer Compile Exception: " + o.message),
			{
			    render: function () { }
			}
	    }
	},
	e.to_html = function (e, t, n) {
	    return n && n === this.options || (n = i(n, this.options)),
		this.compile(e, n).render(t, n._method)
	},
	"undefined" != typeof global && "undefined" == typeof window && e.set("cache", !1),
	"undefined" != typeof module && module.exports ? module.exports = e : this.juicer = e,
	"function" == typeof define && define.amd && define("juicer", [],
	function () {
	    return e
	})
}(),
define("view", ["Backbone", "jquery", "juicer"],
function (e, t, n) {
    var i = function (i, r, o, a, s) {
        var u = t.Deferred();
        return require(["lib/require.text!../template/" + i + ".html"],
		function (i) {
		    r = "object" != typeof r ? {} : r,
			o = "object" != typeof o ? {} : o,
			"undefined" == typeof a ? a = "#mainview" : "object" == typeof a && (s = a, a = "#mainview"),
			r.title && (document.title = r.title);
		    var c = e.View.extend({
		        template: n(i),
		        events: o,
		        initialize: function () {
		            this.$el.off(),
					this.listenTo(this.model, "change", this.render)
		        },
		        render: function () {
		            var e = this,
					n = e.model.toJSON();
		            return n.title && n.title !== document.title && (document.title = n.title, base.device.isWeixin && base.device.isIOS && !
					function () {
					    var e = t('<iframe src="images/pixel.gif" style="visibility:hidden; opacity:0; position:absolute; z-index:-1;"></iframe>');
					    e.on("load",
						function () {
						    setTimeout(function () {
						        e.off("load").remove()
						    },
							0)
						}).appendTo(t("body"))
					}()),
					e.$el.html(e.template.render(e.model.toJSON())),
					e
		        },
		        el: a
		    }),
			l = new e.Model(r),
			f = new c({
			    model: l
			});
		    f.render(),
			s && (f.parentview = s),
			u.resolve(f)
		}),
		u.promise()
    };
    return i
}),
!
function (e, t) {
    "function" == typeof define && (define.amd || define.cmd) ? define("weixin", [],
	function () {
	    return t(e)
	}) : t(e, !0)
}(this,
function (e, t) {
    function n(t, n, i) {
        e.WeixinJSBridge ? WeixinJSBridge.invoke(t, r(n),
		function (e) {
		    a(t, e, i)
		}) : c(t, i)
    }
    function i(t, n, i) {
        e.WeixinJSBridge ? WeixinJSBridge.on(t,
		function (e) {
		    i && i.trigger && i.trigger(e),
			a(t, e, n)
		}) : i ? c(t, i) : c(t, n)
    }
    function r(e) {
        return e = e || {},
		e.appId = C.appId,
		e.verifyAppId = C.appId,
		e.verifySignType = "sha1",
		e.verifyTimestamp = C.timestamp + "",
		e.verifyNonceStr = C.nonceStr,
		e.verifySignature = C.signature,
		e
    }
    function o(e) {
        return {
            timeStamp: e.timestamp + "",
            nonceStr: e.nonceStr,
            "package": e["package"],
            paySign: e.paySign,
            signType: e.signType || "SHA1"
        }
    }
    function a(e, t, n) {
        var i, r, o;
        switch (delete t.err_code, delete t.err_desc, delete t.err_detail, i = t.errMsg, i || (i = t.err_msg, delete t.err_msg, i = s(e, i, n), t.errMsg = i), n = n || {},
		n._complete && (n._complete(t), delete n._complete), i = t.errMsg || "", C.debug && !n.isInnerInvoke && alert(JSON.stringify(t)), r = i.indexOf(":"), o = i.substring(r + 1)) {
            case "ok":
                n.success && n.success(t);
                break;
            case "cancel":
                n.cancel && n.cancel(t);
                break;
            default:
                n.fail && n.fail(t)
        }
        n.complete && n.complete(t)
    }
    function s(e, t) {
        var n, i, r, o;
        if (t) {
            switch (n = t.indexOf(":"), e) {
                case h.config:
                    i = "config";
                    break;
                case h.openProductSpecificView:
                    i = "openProductSpecificView";
                    break;
                default:
                    i = t.substring(0, n),
                    i = i.replace(/_/g, " "),
                    i = i.replace(/\b\w+\b/g,
                    function (e) {
                        return e.substring(0, 1).toUpperCase() + e.substring(1)
                    }),
                    i = i.substring(0, 1).toLowerCase() + i.substring(1),
                    i = i.replace(/ /g, ""),
                    -1 != i.indexOf("Wcpay") && (i = i.replace("Wcpay", "WCPay")),
                    r = g[i],
                    r && (i = r)
            }
            o = t.substring(n + 1),
			"confirm" == o && (o = "ok"),
			"failed" == o && (o = "fail"),
			-1 != o.indexOf("failed_") && (o = o.substring(7)),
			-1 != o.indexOf("fail_") && (o = o.substring(5)),
			o = o.replace(/_/g, " "),
			o = o.toLowerCase(),
			("access denied" == o || "no permission to execute" == o) && (o = "permission denied"),
			"config" == i && "function not exist" == o && (o = "ok"),
			t = i + ":" + o
        }
        return t
    }
    function u(e) {
        var t, n, i, r;
        if (e) {
            for (t = 0, n = e.length; n > t; ++t) i = e[t],
			r = h[i],
			r && (e[t] = r);
            return e
        }
    }
    function c(e, t) {
        if (C.debug && !t.isInnerInvoke) {
            var n = g[e];
            n && (e = n),
			t && t._complete && delete t._complete,
			console.log('"' + e + '",', t || "")
        }
    }
    function l() {
        if (!("6.0.2" > k || S.systemType < 0)) {
            var e = new Image;
            S.appId = C.appId,
			S.initTime = T.initEndTime - T.initStartTime,
			S.preVerifyTime = T.preVerifyEndTime - T.preVerifyStartTime,
			E.getNetworkType({
			    isInnerInvoke: !0,
			    success: function (t) {
			        S.networkType = t.networkType;
			        var n = "https://open.weixin.qq.com/sdk/report?v=" + S.version + "&o=" + S.isPreVerifyOk + "&s=" + S.systemType + "&c=" + S.clientVersion + "&a=" + S.appId + "&n=" + S.networkType + "&i=" + S.initTime + "&p=" + S.preVerifyTime + "&u=" + S.url;
			        e.src = n
			    }
			})
        }
    }
    function f() {
        return (new Date).getTime()
    }
    function d(t) {
        x && (e.WeixinJSBridge ? t() : m.addEventListener && m.addEventListener("WeixinJSBridgeReady", t, !1))
    }
    function p() {
        E.invoke || (E.invoke = function (t, n, i) {
            e.WeixinJSBridge && WeixinJSBridge.invoke(t, r(n), i)
        },
		E.on = function (t, n) {
		    e.WeixinJSBridge && WeixinJSBridge.on(t, n)
		})
    }
    var h, g, m, v, y, x, w, b, k, T, S, C, _, j, E;
    return e.jWeixin ? void 0 : (h = {
        config: "preVerifyJSAPI",
        onMenuShareTimeline: "menu:share:timeline",
        onMenuShareAppMessage: "menu:share:appmessage",
        onMenuShareQQ: "menu:share:qq",
        onMenuShareWeibo: "menu:share:weiboApp",
        previewImage: "imagePreview",
        getLocation: "geoLocation",
        openProductSpecificView: "openProductViewWithPid",
        addCard: "batchAddCard",
        openCard: "batchViewCard",
        chooseWXPay: "getBrandWCPayRequest"
    },
	g = function () {
	    var e, t = {};
	    for (e in h) t[h[e]] = e;
	    return t
	}(), m = e.document, v = m.title, y = navigator.userAgent.toLowerCase(), x = -1 != y.indexOf("micromessenger"), w = -1 != y.indexOf("android"), b = -1 != y.indexOf("iphone") || -1 != y.indexOf("ipad"), k = function () {
	    var e = y.match(/micromessenger\/(\d+\.\d+\.\d+)/) || y.match(/micromessenger\/(\d+\.\d+)/);
	    return e ? e[1] : ""
	}(), T = {
	    initStartTime: f(),
	    initEndTime: 0,
	    preVerifyStartTime: 0,
	    preVerifyEndTime: 0
	},
	S = {
	    version: 1,
	    appId: "",
	    initTime: 0,
	    preVerifyTime: 0,
	    networkType: "",
	    isPreVerifyOk: 1,
	    systemType: b ? 1 : w ? 2 : -1,
	    clientVersion: k,
	    url: encodeURIComponent(location.href)
	},
	C = {},
	_ = {
	    _completes: []
	},
	j = {
	    state: 0,
	    res: {}
	},
	d(function () {
	    T.initEndTime = f()
	}), E = {
	    config: function (e) {
	        C = e,
			c("config", e),
			d(function () {
			    n(h.config, {
			        verifyJsApiList: u(C.jsApiList)
			    },
				function () {
				    _._complete = function (e) {
				        T.preVerifyEndTime = f(),
						j.state = 1,
						j.res = e
				    },
					_.success = function () {
					    S.isPreVerifyOk = 0
					},
					_.fail = function (e) {
					    _._fail ? _._fail(e) : j.state = -1
					};
				    var e = _._completes;
				    return e.push(function () {
				        C.debug || l()
				    }),
					_.complete = function (t) {
					    for (var n = 0,
						i = e.length; i > n; ++n) e[n](t);
					    _._completes = []
					},
					_
				}()),
				T.preVerifyStartTime = f()
			}),
			C.beta && p()
	    },
	    ready: function (e) {
	        0 != j.state ? e() : (_._completes.push(e), !x && C.debug && e())
	    },
	    error: function (e) {
	        "6.0.2" > k || (-1 == j.state ? e(j.res) : _._fail = e)
	    },
	    checkJsApi: function (e) {
	        var t = function (e) {
	            var t, n, i = e.checkResult;
	            for (t in i) n = g[t],
				n && (i[n] = i[t], delete i[t]);
	            return e
	        };
	        n("checkJsApi", {
	            jsApiList: u(e.jsApiList)
	        },
			function () {
			    return e._complete = function (e) {
			        if (w) {
			            var n = e.checkResult;
			            n && (e.checkResult = JSON.parse(n))
			        }
			        e = t(e)
			    },
				e
			}())
	    },
	    onMenuShareTimeline: function (e) {
	        i(h.onMenuShareTimeline, {
	            complete: function () {
	                n("shareTimeline", {
	                    title: e.title || v,
	                    desc: e.title || v,
	                    img_url: e.imgUrl,
	                    link: e.link || location.href
	                },
					e)
	            }
	        },
			e)
	    },
	    onMenuShareAppMessage: function (e) {
	        i(h.onMenuShareAppMessage, {
	            complete: function () {
	                n("sendAppMessage", {
	                    title: e.title || v,
	                    desc: e.desc || "",
	                    link: e.link || location.href,
	                    img_url: e.imgUrl,
	                    type: e.type || "link",
	                    data_url: e.dataUrl || ""
	                },
					e)
	            }
	        },
			e)
	    },
	    onMenuShareQQ: function (e) {
	        i(h.onMenuShareQQ, {
	            complete: function () {
	                n("shareQQ", {
	                    title: e.title || v,
	                    desc: e.desc || "",
	                    img_url: e.imgUrl,
	                    link: e.link || location.href
	                },
					e)
	            }
	        },
			e)
	    },
	    onMenuShareWeibo: function (e) {
	        i(h.onMenuShareWeibo, {
	            complete: function () {
	                n("shareWeiboApp", {
	                    title: e.title || v,
	                    desc: e.desc || "",
	                    img_url: e.imgUrl,
	                    link: e.link || location.href
	                },
					e)
	            }
	        },
			e)
	    },
	    startRecord: function (e) {
	        n("startRecord", {},
			e)
	    },
	    stopRecord: function (e) {
	        n("stopRecord", {},
			e)
	    },
	    onVoiceRecordEnd: function (e) {
	        i("onVoiceRecordEnd", e)
	    },
	    playVoice: function (e) {
	        n("playVoice", {
	            localId: e.localId
	        },
			e)
	    },
	    pauseVoice: function (e) {
	        n("pauseVoice", {
	            localId: e.localId
	        },
			e)
	    },
	    stopVoice: function (e) {
	        n("stopVoice", {
	            localId: e.localId
	        },
			e)
	    },
	    onVoicePlayEnd: function (e) {
	        i("onVoicePlayEnd", e)
	    },
	    uploadVoice: function (e) {
	        n("uploadVoice", {
	            localId: e.localId,
	            isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
	        },
			e)
	    },
	    downloadVoice: function (e) {
	        n("downloadVoice", {
	            serverId: e.serverId,
	            isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
	        },
			e)
	    },
	    translateVoice: function (e) {
	        n("translateVoice", {
	            localId: e.localId,
	            isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
	        },
			e)
	    },
	    chooseImage: function (e) {
	        n("chooseImage", {
	            scene: "1|2",
	            count: e.count || 9,
	            sizeType: e.sizeType || ["original", "compressed"]
	        },
			function () {
			    return e._complete = function (e) {
			        if (w) {
			            var t = e.localIds;
			            t && (e.localIds = JSON.parse(t))
			        }
			    },
				e
			}())
	    },
	    previewImage: function (e) {
	        n(h.previewImage, {
	            current: e.current,
	            urls: e.urls
	        },
			e)
	    },
	    uploadImage: function (e) {
	        n("uploadImage", {
	            localId: e.localId,
	            isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
	        },
			e)
	    },
	    downloadImage: function (e) {
	        n("downloadImage", {
	            serverId: e.serverId,
	            isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
	        },
			e)
	    },
	    getNetworkType: function (e) {
	        var t = function (e) {
	            var t, n, i, r = e.errMsg;
	            if (e.errMsg = "getNetworkType:ok", t = e.subtype, delete e.subtype, t) e.networkType = t;
	            else switch (n = r.indexOf(":"), i = r.substring(n + 1)) {
	                case "wifi":
	                case "edge":
	                case "wwan":
	                    e.networkType = i;
	                    break;
	                default:
	                    e.errMsg = "getNetworkType:fail"
	            }
	            return e
	        };
	        n("getNetworkType", {},
			function () {
			    return e._complete = function (e) {
			        e = t(e)
			    },
				e
			}())
	    },
	    openLocation: function (e) {
	        n("openLocation", {
	            latitude: e.latitude,
	            longitude: e.longitude,
	            name: e.name || "",
	            address: e.address || "",
	            scale: e.scale || 28,
	            infoUrl: e.infoUrl || ""
	        },
			e)
	    },
	    getLocation: function (e) {
	        e = e || {},
			n(h.getLocation, {
			    type: e.type || "wgs84"
			},
			function () {
			    return e._complete = function (e) {
			        delete e.type
			    },
				e
			}())
	    },
	    hideOptionMenu: function (e) {
	        n("hideOptionMenu", {},
			e)
	    },
	    showOptionMenu: function (e) {
	        n("showOptionMenu", {},
			e)
	    },
	    closeWindow: function (e) {
	        e = e || {},
			n("closeWindow", {
			    immediate_close: e.immediateClose || 0
			},
			e)
	    },
	    hideMenuItems: function (e) {
	        n("hideMenuItems", {
	            menuList: e.menuList
	        },
			e)
	    },
	    showMenuItems: function (e) {
	        n("showMenuItems", {
	            menuList: e.menuList
	        },
			e)
	    },
	    hideAllNonBaseMenuItem: function (e) {
	        n("hideAllNonBaseMenuItem", {},
			e)
	    },
	    showAllNonBaseMenuItem: function (e) {
	        n("showAllNonBaseMenuItem", {},
			e)
	    },
	    scanQRCode: function (e) {
	        e = e || {},
			n("scanQRCode", {
			    needResult: e.needResult || 0,
			    scanType: e.scanType || ["qrCode", "barCode"]
			},
			function () {
			    return e._complete = function (e) {
			        var t, n;
			        b && (t = e.resultStr, t && (n = JSON.parse(t), e.resultStr = n && n.scan_code && n.scan_code.scan_result))
			    },
				e
			}())
	    },
	    openProductSpecificView: function (e) {
	        n(h.openProductSpecificView, {
	            pid: e.productId,
	            view_type: e.viewType || 0
	        },
			e)
	    },
	    addCard: function (e) {
	        var t, i, r, o, a = e.cardList,
			s = [];
	        for (t = 0, i = a.length; i > t; ++t) r = a[t],
			o = {
			    card_id: r.cardId,
			    card_ext: r.cardExt
			},
			s.push(o);
	        n(h.addCard, {
	            card_list: s
	        },
			function () {
			    return e._complete = function (e) {
			        var t, n, i, r = e.card_list;
			        if (r) {
			            for (r = JSON.parse(r), t = 0, n = r.length; n > t; ++t) i = r[t],
						i.cardId = i.card_id,
						i.cardExt = i.card_ext,
						i.isSuccess = i.is_succ ? !0 : !1,
						delete i.card_id,
						delete i.card_ext,
						delete i.is_succ;
			            e.cardList = r,
						delete e.card_list
			        }
			    },
				e
			}())
	    },
	    chooseCard: function (e) {
	        n("chooseCard", {
	            app_id: C.appId,
	            location_id: e.shopId || "",
	            sign_type: e.signType || "SHA1",
	            card_id: e.cardId || "",
	            card_type: e.cardType || "",
	            card_sign: e.cardSign,
	            time_stamp: e.timestamp + "",
	            nonce_str: e.nonceStr
	        },
			function () {
			    return e._complete = function (e) {
			        e.cardList = e.choose_card_info,
					delete e.choose_card_info
			    },
				e
			}())
	    },
	    openCard: function (e) {
	        var t, i, r, o, a = e.cardList,
			s = [];
	        for (t = 0, i = a.length; i > t; ++t) r = a[t],
			o = {
			    card_id: r.cardId,
			    code: r.code
			},
			s.push(o);
	        n(h.openCard, {
	            card_list: s
	        },
			e)
	    },
	    chooseWXPay: function (e) {
	        n(h.chooseWXPay, o(e), e)
	    }
	},
	t && (e.wx = e.jWeixin = E), E)
}),
define("wxapi", ["jquery", "weixin", "base"],
function (e, t, n) {
    function i(e) {
        e = e || {},
		t.ready(function () {
		    if (e.hidemenu && t.hideOptionMenu(), e.showmenu && t.showOptionMenu(), e.scan && t.scanQRCode({
		        needResult: "function" == typeof e.scan ? 1 : 0,
		        scanType: ["qrCode", "barCode"],
		        success: function (t) {
					var n = t.resultStr;
					"function" == typeof e.scan && e.scan(n)
		    }
		    }), e.preview && t.previewImage(e.preview), e.pay && t.chooseWXPay({
		        timestamp: e.pay.oldTimeStamp,
		        nonceStr: e.pay.oldNonceStr,
				"package": "prepay_id=" + e.pay.PayId,
		        signType: "MD5",
		        paySign: e.pay.sign,
		        success: function (t) {
					e.pay.reload ? window.location.reload() : location.hash = e.pay.hash
		    },
		        cancel: function (e) {
					n.ui.alert("您已经取消了支付")
		    },
		        fail: function (t) {
					n.ui.alert("支付失败",
					function () {
						e.pay.hash && (location.hash = e.pay.hash + "/fail")
		    })
		    }
		    }), e.share && "object" == typeof e.share && "[object object]" === Object.prototype.toString.call(e.share).toLowerCase()) {
		        var i = (location.origin + location.pathname, e.share);
		        t.onMenuShareAppMessage({
		            desc: i.desc,
		            title: i.title,
		            link: i.link,
		            imgUrl: i.imgUrl,
		            type: "",
		            dataUrl: "",
		            success: function () {
		                "function" == typeof e.share.callback && e.share.callback("分享朋友圈")
		            },
		            cancel: function () { }
		        }),
				t.onMenuShareTimeline({
				    title: i.title2 || i.title,
				    link: i.link,
				    imgUrl: i.imgUrl,
				    success: function () {
				        "function" == typeof e.share.callback && e.share.callback("分享给朋友")
				    },
				    cancel: function () { }
				})
		    }
		})
    }
    var r = function (n, r, o) {
        if (!window.wxtoken || r) {
            var a = location.origin + location.pathname,
			s = {
			    Htmlurl: a
			};
            r && (s.openid = r),
			e.ajax("/API/WxAbout/GetWXtoken", {
			    type: "post",
			    data: s,
			    beforeSend: function () { },
			    complete: function () { }
			}).done(function (e) {
			    e = JSON.parse(e),
				window.wxtoken = e,
				(!window.wxconfig || r) && (t.config({
				    debug: !1,
				    appId: window.wxtoken.appId,
				    timestamp: window.wxtoken.timestamp,
				    nonceStr: window.wxtoken.nonceStr,
				    signature: window.wxtoken.signature,
				    jsApiList: ["checkJsApi", "onMenuShareTimeline", "onMenuShareAppMessage", "onMenuShareQQ", "onMenuShareWeibo", "hideMenuItems", "showMenuItems", "hideAllNonBaseMenuItem", "showAllNonBaseMenuItem", "translateVoice", "startRecord", "stopRecord", "onRecordEnd", "playVoice", "pauseVoice", "stopVoice", "uploadVoice", "downloadVoice", "chooseImage", "previewImage", "uploadImage", "downloadImage", "getNetworkType", "openLocation", "getLocation", "hideOptionMenu", "showOptionMenu", "closeWindow", "scanQRCode", "chooseWXPay", "openProductSpecificView", "addCard", "chooseCard", "openCard"]
				}), window.wxconfig = !0),
				"function" == typeof o && o(),
				i(n)
			})
        } else i(n)
    };
    return r
}),
define("funcs", ["jquery", "wxapi", "base", "juicer"],
function (e, t, n, i) {
    var r = {
        searchFocus: function (e) {
            var t = this.$el.find(".search");
            t.hasClass("show") || t.addClass("show")
        },
        searchBlur: function (e) {
            var t = this.$el.find(".search");
            t.hasClass("show") && setTimeout(function () {
                t.removeClass("show")
            },
			200)
        },
        clearSearch: function () {
            var e = this.$el.find(".search input");
            e.val("")
        },
        searchSubmit: function (t) {
            var i, r = this.$el.find(t.currentTarget),
			o = r.prevAll("input").eq(0).val();
            if (this.oldlist2 || (this.oldlist2 = this.oldlist), o || "undefined" == typeof this.query) {
                if (!o) return n.ui.alert("搜索条件不能为空"),
				!1;
                e.ajax("/Api/Shop/SearchShopClass", {
                    data: {
                        word: o
                    }
                }).done(function (e) {
                    return 1 !== e.status ? (n.ui.alert(e.msg), !1) : (this.model.set("classlist", e.info), this.oldlist = e.info, this.query = o, void this.render())
                }.bind(this))
            } else this.oldlist = this.oldlist2,
			i = this.oldlist.map(function (e) {
			    return e
			}),
			this.model.set("classlist", i),
			delete this.query,
			this.render()
        },
        showSort: function (e) {
            var t = this.$el.find(e.currentTarget),
			n = this.$el.find(".top-pop"),
			i = {
			    sort: ".sort-items",
			    filter: ".filter-type"
			}[e.currentTarget.className];
            n.hasClass("show") && !t.data("show") && this.$el.find(".top .current").removeClass("current").parent().data("show", !1),
			t.data("show") ? (t.data("show", !1).find(".iconfont").removeClass("current"), n.removeClass("show").find(i).removeClass("animate")) : (t.data("show", !0).find(".iconfont").addClass("current"), n.addClass("show").find(i).addClass("animate").siblings().removeClass("animate"))
        },
        selectSort: function (e) {
            var t = this.$el.find(e.currentTarget),
			n = this.oldlist.map(function (e) {
			    return e
			}),
			i = this.model.get("filter");
            switch (t.addClass("active").siblings().removeClass("active"), parseInt(t.attr("data-sort"))) {
                case 0:
                    n = n.sort(function (e, t) {
                        return e.sellingprice - t.sellingprice
                    });
                    break;
                case 1:
                    n = n.sort(function (e, t) {
                        return t.sellingprice - e.sellingprice
                    })
            }
            i.oederby = parseInt(t.attr("data-sort")),
			this.model.set("classlist", n),
			this.render()
        },
        menuCtrl: function (t) {
            var i = this.$el.find(t.currentTarget);
            if (t.currentTarget.classList.contains("cancle")) i.parents(".filter-box").eq(0).removeClass("animate"),
			"1" === t.currentTarget.dataset.level && (e(".top-pop").removeClass("show"), e(".filter").data("show", !1).find(".current").removeClass("current"));
            else if (t.currentTarget.classList.contains("confirm")) if ("1" === t.currentTarget.dataset.level) {
                var r = this,
				o = this.model.get("filter"),
				a = e.extend(!0, {},
				o);
                if (r.$el.find(".type-list li").each(function () {
					var t = e(this);
					a[t.data("key")] = t.find(".val").data("selectid")
                }), JSON.stringify(a) === JSON.stringify(o)) return r.render(),
				!1;
                e.ajax("/Api/Shop/GetShopClass", {
                    data: a
                }).done(function (e) {
                    return 1 !== e.status ? (n.ui.alert(e.msg), !1) : (r.model.set("classlist", e.info), r.model.set("filter", a), r.oldlist = e.info.map(function (e) {
                        return e
                    }), void r.render())
                })
            } else i.parents(".filter-box").eq(0).removeClass("animate");
            t.stopPropagation()
        },
        showFilter: function (t) {
            var n = t.currentTarget.dataset.index,
			r = {
			    list: this.model.get("classtype")[n].list,
			    select: this.model.get("classtype")[n].select
			},
			o = e("#tmp-option").html();
            o = o.replace(/\@\-/g, "@").replace(/\$\-/g, "$"),
			this.$el.find(".filter-option").addClass("animate").data("tid", n).find(".option-list").html(i(o).render(r))
        },
        repeatType: function () {
            var t = this.model.get("classtype"),
			n = e("#tmp-type").html();
            n = n.replace(/\@\-/g, "@").replace(/\$\-/g, "$").replace("e-l-s-e", "else"),
			t = t.map(function (e, t) {
			    return delete e.select,
				delete e.selectid,
				e
			}),
			this.$el.find(".type-list").html(i(n).render({
			    list: t
			}))
        },
        selectFilter: function (t) {
            var n = this.$el.find(t.currentTarget),
			r = this.$el.find(".filter-option"),
			o = r.data("tid"),
			a = this.model.get("classtype"),
			s = e("#tmp-type").html();
            s = s.replace(/\@\-/g, "@").replace(/\$\-/g, "$").replace("e-l-s-e", "else"),
			a[o].select = n.find(".val").text(),
			a[o].selectid = n.data("id"),
			r.removeClass("animate"),
			this.$el.find(".type-list").html(i(s).render({
			    list: a
			}))
        },
        topCtrl: function (t) {
            var i = this.$el.find(t.currentTarget),
			r = this.model.get("detail"),
			o = this.model.get("uid"),
			a = this.model.get("id"),
			s = "x";
            if (!o) return n.ui.alert("请先登录再进行操作"),
			!1;
            switch (t.currentTarget.className) {
                case "one":
                    if (r.iflike) return !1;
                    s = 1;
                    break;
                case "two":
                    if (r.ifFav) return !1;
                    s = 0;
                    break;
                case "three":
            }
            if (1 === s || 0 === s) {
                if ("share" === o) return n.ui.alert("匿名用户无法添加收藏和喜欢"),
				!1;
                e.ajax({
                    url: "/api/shop/AddFAV",
                    data: {
                        shcid: a,
                        uid: o,
                        type: s
                    }
                }).done(function (e) {
                    0 === s ? r.ifFav = 1 : 1 === s && (r.iflike = 1),
					i.addClass("current").siblings().removeClass("current")
                })
            }
        },
        selectNumber: function (e) {
            var t = this.model.get("detail");
            if (0 === t.total) return !1;
            var i = this.$el.find(".onum"),
			r = parseInt(i.text());
            switch (e.target.className) {
                case "minus":
                    r > 1 && i.html(r - 1);
                    break;
                case "plus":
                    r < t.total ? i.html(r + 1) : n.ui.alert("购买数量不能超过商品总数")
            }
        },
        showDate: function () {
            var t = this.model.get("detail");
            t.classdate && t.classdate.length ? e(".date-box").addClass("show-date") : n.ui.alert("暂无开课时间")
        },
        confirmDate: function () {
            var t = e(".show-select").find("span").html();
            t && e(".deposit-date").html(t).show(),
			e(".date-box").removeClass("show-date")
        },
        submitBuy: function (t) {
            var i = parseInt(this.$el.find(".onum").text()),
			r = this.$el.find(".deposit-date").text();
            return r ? n.device.isWeixin ? (n.ui.alert("暂不支持微信支付，请从浏览器端打开用支付宝支付"), !1) : (n.tool.cookie.set("onum", i), void n.tool.cookie.set("odate", r)) : (n.ui.alert("请选择开班时间",
			function () {
			    e(".select-date").click()
			}), !1)
        },
        commsOption: function (e) {
            var t = this.$el.find(e.currentTarget).find(".name em").text(),
			n = this.$el.find(".reply-text");
            e.currentTarget.dataset.id && (this.rid = e.currentTarget.dataset.id, this.rname = t, n.val("回复" + t + ": "))
        },
        commSubmit: function () {
            var t = this.model.get("id"),
			i = this.model.get("uid"),
			r = this.$el.find(".reply-text").val(),
			o = this.rid ? this.rid : "";
            new RegExp("^回复" + this.rname + ":s*");
            return this.rname && (0 !== r.indexOf("回复" + this.rname + ": ", "") ? o = "" : r = r.replace("回复" + this.rname + ": ", "")),
			e.trim(r) ? void e.ajax("/api/shop/AddShopComment", {
			    data: {
			        shcid: t,
			        uid: i,
			        content: r,
			        reid: o
			    }
			}).done(function (e) {
			    return 1 !== e.status ? (n.ui.alert(e.msg), !1) : (window.location.hash = "#dssppl/" + t + "/3/" + i, void window.location.reload())
			}) : (n.ui.alert("请输入评论内容"), !1)
        },
        accOrder: function () {
            var i = (this.model.get("uid"), this.model.get("openid")),
			r = this.model.get("detail"),
			o = this.$el.find(".account-form").serialize(),
			a = "";
            return -1 !== o.indexOf("name=&") ? (n.ui.alert("姓名不能为空"), !1) : -1 !== o.indexOf("tel=&") ? (n.ui.alert("手机号不能为空"), !1) : n.regexp.phone(this.$el.find("[name=tel]").val()) ? 0 === r.kind ? (e.ajax("/api/shop/AddClubOrder", {
                data: o
            }).done(function (e) {
                return 1 !== e.status ? (n.ui.alert(e.msg), !1) : void (location.hash = "#odetail/" + e.info)
            }), !1) : (e.ajax("/api/shop/AddOrder", {
                data: o
            }).then(function (t) {
                return 1 !== t.status ? (n.ui.alert(t.msg), !1) : (a = t.info, e.ajax({
                    url: "/api/WeiXinPay/Pay",
                    data: {
                        openid: i,
                        orderid: t.info
                    }
                }))
            }).done(function (e) {
                return e === !1 ? !1 : 1 !== e.status ? (n.ui.alert(e.msg), !1) : void (e.info.payurl ? location.href = e.info.payurl : (e.info.hash = "#odetail/" + a + "/" + i, t(null, i,
				function () {
				    t({
				        pay: e.info
				    })
				})))
            }), !1) : (n.ui.alert("请输入有效的手机号码"), !1)
        },
        cancelOrder: function () {
            n.ui.confirm("确认取消这个订单么？",
			function () {
			    var t = this.model.get("oid");
			    e.ajax("/api/shop/COrder", {
			        data: {
			            id: t
			        }
			    }).done(function (e) {
			        return 1 !== e.status ? (n.ui.alert(e.msg), !1) : (this.model.get("detail").status = 0, void this.render())
			    }.bind(this))
			}.bind(this))
        },
        buyOrder: function () {
            var i = this.model.get("openid"),
			r = this.model.get("oid");
            e.ajax({
                url: "/api/WeiXinPay/Pay",
                data: {
                    openid: i,
                    orderid: r
                }
            }).done(function (e) {
                return 1 !== e.status ? (n.ui.alert(e.msg), !1) : void (e.info.payurl ? location.href = e.info.payurl : (e.info.hash = "#odetail/" + r + "/" + i, t(null, i,
				function () {
				    t({
				        pay: e.info
				    })
				})))
            })
        },
        filterOrder: function (t) {
            var n = this.$el.find(t.currentTarget),
			i = n.index(),
			r = [];
            if (n.hasClass("active")) return !1;
            switch (i) {
                case 0:
                    r = e.grep(this.olist,
                    function (e) {
                        return 1 === e.status
                    });
                    break;
                case 1:
                    r = e.grep(this.olist,
                    function (e) {
                        return 2 === e.status
                    });
                    break;
                case 2:
                    r = this.olist.map(function (e) {
                        return e
                    })
            }
            n.addClass("active").siblings().removeClass("active"),
			this.model.set("index", i),
			this.model.set("list", r)
        },
        boboEnroll: function (e) {
            return e.currentTarget.classList.contains("disabled") ? (n.ui.alert("本次课程已失效"), !1) : void 0
        },
        saveBasic: function () {
            var e = this.$el.find(".basic-form").serialize(),
			t = n.tool.unserialize(e);
            return t.name ? t.age ? t.sex ? t.job ? void n.tool.cookie.set("evbasic", e) : (n.ui.alert("请选择你现在的职位"), !1) : (n.ui.alert("请选择你的性别"), !1) : (n.ui.alert("年龄不能为空"), !1) : (n.ui.alert("姓名不能为空"), !1)
        },
        selectAnswer: function (e) {
            var t = this.$el.find(e.currentTarget),
			i = this.model.get("uid"),
			r = this.model.get("idx");
            t.addClass("active").siblings("li").removeClass("active"),
			setTimeout(function () {
			    var e = n.tool.cookie.get("evanswer").split(";");
			    index = t.index(),
				e[r - 1] = index,
				n.tool.cookie.set("evanswer", e.join(";")),
				location.hash = "evaluating/" + (parseInt(r) + 1) + "/" + i
			},
			200)
        }
    };
    return r
}),
define("calendar", ["jquery"],
function () {
    var e = {
        init: function (e, t, n) {
            this.dates = t,
			this.now = new Date,
			this.oBox = $("#date"),
			this.oBox.html(""),
			this.createMonth(),
			this.createWeek(),
			this.createDate(),
			this.selectDate = "",
			n && this.update(n)
        },
        createMonth: function () {
            var e = this;
            e.oldDate = e.now.getDate(),
			e.changeDate = 0,
			e.year = e.now.getFullYear(),
			e.month = e.now.getMonth(),
			$('<div class="month"><a class="change-prev" href="javascript:;"></a><span></span><a class="change-next" href="javascript:;"></a></div>').appendTo(e.oBox),
			e.oBox.find(".month").find("span").html(this.year + "年" + (this.month + 1) + "月").end().on("click",
			function (t) {
			    t.clientX < $(t.currentTarget).offset().left + t.currentTarget.clientWidth / 2 ? e.update(-1) : e.update(1)
			})
        },
        update: function (e) {
            var t = 1;
            this.changeDate += e,
			0 == this.changeDate && (t = this.oldDate),
			this.now = new Date((new Date).setFullYear(this.year, this.month + e, t)),
			this.year = this.now.getFullYear(),
			this.month = this.now.getMonth(),
			this.oBox.find(".month").find("span").html(this.year + "年" + (this.month + 1) + "月"),
			this.createDate()
        },
        createWeek: function () {
            for (var e = ["日", "一", "二", "三", "四", "五", "六"], t = $('<ul class="week-list clearfix"></ul>'), n = 0; n < e.length; n++) {
                var i = $("<li></li>"); (0 == n || n == e.length - 1) && i.addClass("red"),
				i.html(e[n]).appendTo(t)
            }
            t.appendTo(this.oBox)
        },
        createDate: function () {
            var e = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31],
			t = this.oBox.find(".date-list").length ? this.oBox.find(".date-list") : $('<ul class="date-list clearfix"></ul>'),
			n = this.getFirstDay(this.now.getTime()),
			i = this.getLastDay(this.now.getTime()),
			r = "",
			o = "",
			a = this,
			s = 0,
			u = this.now.getDate();
            this.now.getFullYear() % 4 === 0 && (e[1] = 29),
			t.html(""),
			a.changeDate < 0 ? u = 31 : a.changeDate > 0 && (u = 0);
            for (var c = n - 1; c >= 0; c--) 0 == a.month ? (s = 11, r = a.year - 1 + "-12-" + (e[s] - c)) : (s = a.month - 1, r = a.year + "-" + (a.month >= 10 ? a.month : "0" + a.month) + "-" + (e[s] - c)),
			o += '<li class="before gray" data-date="' + r + '"></li>';
            for (var l = 1; l <= e[a.month]; l++) o += '<li class="',
			r = a.year + "-" + (a.month + 1 >= 10 ? a.month + 1 : "0" + (a.month + 1)) + "-" + (l >= 10 ? l : "0" + l),
			-1 != $.inArray(r, a.dates) ? (o += u > l ? 'sign gray" data-date="' + r + '">' : r === a.selectDate ? 'sign current" data-date="' + r + '">' : 'sign" data-date="' + r + '">', o += l + "<br>开课</li>") : (o += 'gray" data-date="' + r + '">', o += l + "</li>");
            for (var f = i + 1; 7 > f; f++) r = 11 == a.month ? a.year + 1 + "-01-0" + (f - i) : a.year + "-" + (a.month + 2 >= 10 ? a.month + 2 : "0" + (a.month + 2)) + "-0" + (f - i),
			o += '<li class="after gray" data-date="' + r + '"></li>';
            a.oBox.find(".date-list").length ? t.append(o) : t.append(o).appendTo(a.oBox),
			t.on("click", ".sign",
			function (e) {
			    return $(this).hasClass("gray") || (a.selectDate = $(this).data("date"), $(this).addClass("current").siblings().removeClass("current"), a.oBox.find(".show-select").length ? a.oBox.find(".show-select").html("您已选择：<span>" + a.selectDate + "</span>") : $('<div class="show-select">您已选择：<span>' + a.selectDate + "</span></div>").appendTo(a.oBox)),
				e.stopPropagation(),
				e.preventDefault(),
				!1
			})
        },
        getFirstDay: function (e) {
            var t = new Date(e);
            return t.setDate(1),
			t.getDay()
        },
        getLastDay: function (e) {
            var t = new Date(e),
			n = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            return this.now.getFullYear() % 4 === 0 && (n[1] = 29),
			t.setDate(n[t.getMonth()]),
			t.getDay()
        }
    };
    return e
}),
define("qas", [],
function () {
    var e = [{
        title: "你当发型师多久了？",
        option: ["12年以上", "9至12年", "6至8年", "2至5年", "1年以内"]
    },
	{
	    title: "你的剪发价位？",
	    option: ["150元以上", "85-150元", "50-80元", "25-40元", "20元以下"]
	},
	{
	    title: "你的男客比例？",
	    option: ["10%", "20%-30%", "40%-60%", "70%-80%", "90%"]
	},
	{
	    title: "你的月均预约率（点客率）？",
	    option: ["90%", "60%-80%", "30%-50%", "10%-20%", "5%以下"]
	},
	{
	    title: "你的月剪女客数量？",
	    option: ["130人以上", "110-130人", "90-100人", "60-80人", "50人以下"]
	},
	{
	    title: "你的月单独吹风造型客数？",
	    option: ["130人以上", "110-130人", "90-100人", "60-80人", "50人以下"]
	},
	{
	    title: "你的月烫发客数？",
	    option: ["60人以上", "50-60人", "35-45人", "20-30人", "15人以下"]
	},
	{
	    title: "你的月染发客数？",
	    option: ["60人以上", "50-60人", "35-45人", "20-30人", "15人以下"]
	},
	{
	    title: "你的月护理客数？",
	    option: ["45人以上", "35-40人", "25-30人", "15-20人", "10人以内"]
	},
	{
	    title: "你的月盘发扎发客数？",
	    option: ["45人以上", "35-40人", "25-30人", "15-20人", "10人以内"]
	},
	{
	    title: "你当发型师是因为？",
	    option: ["自己选择", "朋友介绍", "父母安排", "工作而已", "暂时做做 "]
	},
	{
	    title: "你对美发工作的态度？",
	    option: ["追求到底", "很喜欢", "喜欢", "一般般", "不喜欢"]
	},
	{
	    title: "你觉得美发师是一个什么样的工作？",
	    option: ["设计艺术家", "时尚设计师", "美化师", "手艺活", "服务业"]
	},
	{
	    title: "你的目前月收入？",
	    option: ["12000元以上", "8000元左右", "6000元左右", "4000元左右", "2500元左右"]
	},
	{
	    title: "你喜欢什么风格的技术？",
	    option: ["柔美风格（日式类）", "淑女风格（韩式类）", "优雅风格（中式类）", "欧美风格（大气类）", "几何风格（硬线类）"]
	},
	{
	    title: "你每年学习的次数？",
	    option: ["每年四次", "每年三次", "每年二次", "每年一次", "从没有学习过"]
	}];
    return e
}),
define("routes", ["jquery", "base", "view", "funcs", "wxapi", "calendar", "qas"],
function (e, t, n, i, r, o, a) {
    e.ajaxSetup({
        type: "post",
        beforeSend: function () {
            t.ui.createWait()
        },
        error: function () {
            t.ui.alert("系统错误，请稍后重试！")
        },
        complete: function () {
            t.ui.closeWait()
        }
    });
    var s = {
        notFound: function () {
            t.ui.alert("页面不存在，请检查你输入的地址是否正确！")
        },
        router: function (e) {
            var t = this;
            return function () {
                t.global(e),
				t[e].apply(null, arguments)
            }
        },
        global: function (e) {
            "detail" !== e && t.device.isWeixin && r({
                hidemenu: !0
            })
        },
        index: function (i) {
            e.when("share" === i ? [{
                info: {
                    nickname: "匿名用户",
                    logo: "images/anonymous.png",
                    attach: !0
                },
                status: 1
            }] : e.ajax("/api/shop/GetUserInfo", {
                data: {
                    uid: i
                }
            }), e.ajax("/api/shop/GetBanner2"), e.ajax("/api/shop/GetShopDefult", {
                data: {
                    uid: i
                }
            })).done(function (e, r, o) {
                if (e = e[0], r = r[0], o = o[0], 1 !== e.status) return t.ui.alert(e.msg),
				!1;
                var a = {
                    uid: i,
                    user: e.info,
                    banners: r.info,
                    goods: o.info
                };
                n("home", a, {})
            })
        },
        classlist: function (r) {
            var o = {
                uid: r
            },
			a = {
			    "focus .search input": i.searchFocus,
			    "blur .search input": i.searchBlur,
			    "click .clear-input": i.clearSearch,
			    "click .search-btn": i.searchSubmit,
			    "click .sort": i.showSort,
			    "click .sort-items a": i.selectSort,
			    "click .filter": i.showSort,
			    "click .menu a": i.menuCtrl,
			    "click .type-list li": i.showFilter,
			    "click .repeat-type": i.repeatType,
			    "click .option-list li": i.selectFilter
			};
            e.when(e.ajax("/Api/Shop/GetShopClass", {
                data: {
                    month: -1,
                    city: -1,
                    type: -1,
                    cuid: -1,
                    oederby: -1,
                    pageindex: 1,
                    pagesize: 100
                }
            }), e.ajax("/Api/Shop/GetShoptype")).done(function (e, i) {
                return e = e[0],
				i = i[0],
				1 !== e.status ? (t.ui.alert(e.msg), !1) : 1 !== i.status ? (t.ui.alert(i.msg), !1) : (o.classlist = e.info, o.classtype = i.info, o.classtype.unshift({
				    key: "month",
				    name: "月份",
				    list: [{
				        id: "-1",
				        val: "全部"
				    },
					{
					    id: "1",
					    val: "1月"
					},
					{
					    id: "2",
					    val: "2月"
					},
					{
					    id: "3",
					    val: "3月"
					},
					{
					    id: "4",
					    val: "4月"
					},
					{
					    id: "5",
					    val: "5月"
					},
					{
					    id: "6",
					    val: "6月"
					},
					{
					    id: "7",
					    val: "7月"
					},
					{
					    id: "8",
					    val: "8月"
					},
					{
					    id: "9",
					    val: "9月"
					},
					{
					    id: "10",
					    val: "10月"
					},
					{
					    id: "11",
					    val: "11月"
					},
					{
					    id: "12",
					    val: "12月"
					}]
				}), o.filter = {
				    pageindex: 1,
				    pagesize: 100,
				    oederby: -1
				},
				void n("classlist", o, a).done(function (t) {
				    t.oldlist = e.info.map(function (e) {
				        return e
				    })
				}))
            })
        },
        detail: function (a, s, u) {
            -1 !== location.search.indexOf("from=") && location.replace(location.origin + location.pathname + location.hash);
            var c = {
                id: a,
                uid: s,
                link: window.location.href,
                openid: u
            },
			l = {
			    "click .detail-top a": i.topCtrl,
			    "click .number": i.selectNumber,
			    "click .select-date": i.showDate,
			    "click .confrim-date": i.confirmDate,
			    "click .buy-btn": i.submitBuy
			};
            e.ajax("/api/shop/GetShopClassdetital", {
                data: {
                    id: a,
                    uid: s
                }
            }).done(function (i) {
                if (1 !== i.status) return t.ui.alert(i.msg,
				function () {
				    window.history.back()
				}),
				!1;
                var s = i.info.classdate,
				u = i.info.tdate;
                c.detail = i.info,
				n("detail", c, l).done(function () {
				    require(["Swiper"],
					function (e) {
					    new e(".swiper-container", {
					        pagination: ".swiper-pagination",
					        paginationClickable: !0
					    })
					}),
					o.init(e("#date"), s, u)
				}),
				t.device.isWeixin && r({
				    showmenu: !0,
				    share: {
				        imgUrl: "http://img.hairbobo.com" + i.info.image,
				        link: location.origin + location.pathname + "#detail/" + a + "/share",
				        desc: "我觉得" + i.info.title + "非常赞，感兴趣的去看看哦~",
				        title: "我觉得" + i.info.title + "非常赞，感兴趣的去看看哦~",
				        callback: function (e) { }
				    }
				})
            })
        },
        dssppl: function (r, o, a) {
            var s = {
                id: r,
                uid: a,
                index: o
            },
			u = {
			    "click .review-list a": i.commsOption,
			    "click .reply-submit": i.commSubmit
			};
            return 1 != o && 2 != o && 3 != o ? (t.ui.alert("页面不存在，请检查你输入的地址是否正确！"), !1) : void e.when(e.ajax("/api/shop/GetShopClassdetital", {
                data: {
                    id: r
                }
            }), e.ajax("/api/shop/GetShopComment", {
                data: {
                    id: r
                }
            })).done(function (i, r) {
                return i = i[0],
				r = r[0],
				1 !== i.status ? (t.ui.alert(i.msg), !1) : 1 !== r.status ? (t.ui.alert(r.msg), !1) : (s.detail = i.info, s.comms = r.info, void n("dssppl", s, u).done(function (t) {
				    require(["Swiper"],
					function (n) {
					    var i = t.$el.find(".dssppl-type a"),
						r = new n(".swiper-container", {
						    paginationClickable: !0,
						    initialSlide: parseInt(o) - 1,
						    scrollbar: ".swiper-scrollbar",
						    scrollbarHide: !1,
						    onSlideChangeStart: function (e) {
						        i.eq(e.activeIndex).addClass("active").siblings().removeClass("active")
						    }
						});
					    i.on("click",
						function () {
						    r.slideTo(e(this).index())
						})
					})
				}))
            })
        },
        accounts: function (r, o, a) {
            var s = parseInt(t.tool.cookie.get("onum")),
			u = t.tool.cookie.get("odate"),
			c = {
			    id: r,
			    uid: o,
			    num: s,
			    date: u,
			    openid: a
			},
			l = {
			    "click .acc-btn": i.accOrder
			};
            e.when(e.ajax("/api/shop/GetShopClassdetital", {
                data: {
                    id: r
                }
            }), e.ajax("/api/shop/GetOrderAddress", {
                data: {
                    uid: o
                }
            })).done(function (e, i) {
                return e = e[0],
				i = i[0],
				1 !== e.status ? (t.ui.alert(e.msg), !1) : (c.paytype = t.device.isWeixin ? 2 : 1, c.detail = e.info, c.address = 1 !== i.status ? {} : i.info, void n("accounts", c, l))
            })
        },
        odetail: function (r, o) {
            !o && t.device.isWeixin && (location.href = location.origin + "/home/GetOpenID/?htmlurl=odetail/" + r);
            var a = {
                oid: r,
                openid: o
            },
			s = {
			    "click .cancel-btn": i.cancelOrder,
			    "click .buy-btn": i.buyOrder
			};
            e.ajax("/api/shop/GetOrderinfo", {
                data: {
                    id: r
                }
            }).done(function (e) {
                return 1 !== e.status ? (t.ui.alert(e.msg), !1) : (a.detail = e.info, void n("odetail", a, s))
            })
        },
        olist: function (r) {
            var o = {
                uid: r
            },
			a = {
			    "click .order-type a": i.filterOrder
			};
            e.ajax("/api/shop/GetOrder", {
                data: {
                    uid: r
                }
            }).done(function (e) {
                return 1 !== e.status ? (t.ui.alert(e.msg), !1) : (o.list = e.info, void n("olist", o, a).done(function (t) {
                    t.olist = e.info
                }))
            })
        },
        boboclass: function (r) {
            e.ajax("/Api/Shop/GetClub").done(function (e) {
                if (1 !== e.status) return t.ui.alert(e.msg),
				!1;
                var o = {
                    uid: r
                },
				a = {
				    "click .enroll-btn": i.boboEnroll
				};
                o.month = e.info.month,
				o.list = e.info.list,
				n("boboclass", o, a)
            })
        },
        evaluating: function (r, o) {
            if (r = parseInt(r), isNaN(r) || 0 !== r && r !== a.length && !a[r]) return t.ui.alert("页面不存在，请检查你输入的地址是否正确！"),
			!1;
            var s = {
                idx: r,
                uid: o
            },
			u = {
			    "click .save-basic": i.saveBasic,
			    "click .list li": i.selectAnswer
			},
			c = t.tool.cookie.get("evbasic");
            c = t.tool.unserialize(c),
			0 === r ? (s.basic = c, s.jobs = ["助理", "技师", "师发型", "总监", "老板"], n("evaluating", s, u)) : r === a.length ? e.ajax("/api/shop/GetTest", {
			    data: {
			        uid: o,
			        age: c.age,
			        sex: c.sex,
			        name: c.name,
			        position: c.job,
			        answer: t.tool.cookie.get("evanswer")
			    }
			}).done(function (e) {
			    return 1 !== e.status ? (t.ui.alert(e.msg), !1) : (s.level = e.info, s.len = a.length, void n("evaluating", s, {}))
			}) : (s.qa = a[r - 1], s.active = t.tool.cookie.get("evanswer").split(";")[r - 1], n("evaluating", s, u))
        }
    };
    return s
}),
define("app", ["Backbone", "routes"],
function (e, t) {
    return {
        init: function () {
            var n = e.Router.extend({
                routes: {
                    "index/:uid": t.router("index"),
                    "classlist/:uid": t.router("classlist"),
                    "detail/:id/:uid/:openid": t.router("detail"),
                    "detail/:id/:uid": t.router("detail"),
                    "dssppl/:id/:index/:uid": t.router("dssppl"),
                    "accounts/:id/:uid/:openid": t.router("accounts"),
                    "accounts/:id/:uid": t.router("accounts"),
                    "olist/:uid": t.router("olist"),
                    "odetail/:oid/:openid": t.router("odetail"),
                    "odetail/:oid": t.router("odetail"),
                    "boboclass/:uid": t.router("boboclass"),
                    "evaluating/:index/:uid": t.router("evaluating"),
                    "*anything": t.router("notFound")
                }
            });
            new n,
			e.history.start({
			    pushstate: !0
			})
        }
    }
}),
require.config({
    baseUrl: "./js/",
    paths: {
        jquery: "lib/jquery",
        lazyload: "lib/jquery.lazyload",
        underscore: "lib/underscore",
        Backbone: "lib/backbone",
        juicer: "lib/juicer.min",
        Swiper: "lib/swiper.min",
        weixin: "lib/jweixin-1.0.0",
        calendar: "calendar",
        base: "base",
        app: "app",
        view: "view",
        funcs: "funcs",
        qas: "qas"
    },
    shim: {
        Backbone: {
            exports: "Backbone",
            deps: ["jquery", "underscore"]
        },
        jquery: {
            exports: "$"
        },
        lazyload: {
            deps: ["jquery"]
        },
        iscroll: {
            exports: "IScroll"
        }
    }
}),
define("main", ["app"],
function (e) {
    e.init()
});