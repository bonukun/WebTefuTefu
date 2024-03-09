<template>
  <header>
    <h2>WebTefuTefu</h2>
    <nav>
      <ul>
        <!-- 他のリンクを追加 -->
        <li><a href="/">Home</a></li>
      </ul>
    </nav>
  </header>
</template>

<style scoped>
header {
  background-image: linear-gradient(rgb(42, 234, 255), rgb(255, 255, 255));
  color: rgb(0, 0, 0);
  padding: 1.5rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

nav ul {
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
}

nav li {
  margin-left: 1rem; /* リンクの間隔を調整 */
}

nav a {
  text-decoration: none;
  color: rgb(0, 0, 0);
}
</style>
