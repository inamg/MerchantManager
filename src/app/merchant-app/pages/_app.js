import '../styles/globals.css'
import { ApolloProvider } from '@apollo/react-hooks';
import { useApollo } from '../utils/apollo';

function MyApp({ Component, pageProps }) {
  const apolloClient = useApollo(pageProps.initialApolloState);
  return (
    <ApolloProvider client={apolloClient}>
      <Component {...pageProps} />
   </ApolloProvider>
  )
}

export default MyApp
